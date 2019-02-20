using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
#if NETCOREAPP1_0 || NETCOREAPP2_0 || NETCOREAPP2_1
using System.Runtime.Loader;
#endif
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Configuration;
using odec.Framework.Extensions;
using odec.Framework.Generic.Utility;
using odec.Framework.Infrastructure.Enumerations;
using odec.Framework.Logging;
using Module = Autofac.Module;

namespace odec.Framework.Infrastructure.Autofac
{
    public class ModuleRegistrant : Module
    {
        protected readonly RegistrantOptions RegistrantOptions = new RegistrantOptions();
        /// <summary>
        /// By Default registers all modules specified in lookupAssemblies.json in root directory which ends with Repository
        /// </summary>
        public ModuleRegistrant()
        {
            var checkedDir = SearchUtils.CheckCommonAssemblyStoresForFile(RegistrantOptions.LookupFileNames);
            if (string.IsNullOrEmpty(checkedDir)) checkedDir = Directory.GetCurrentDirectory(); 
            
            var cfgBuilder = new ConfigurationBuilder()
                .SetBasePath(checkedDir);
            
            foreach (var fileName in RegistrantOptions.LookupFileNames)
            {
                var ext = Path.GetExtension(fileName);
                if (ext == ConfigurationFileTypes.Json.GetCode())
                {
                    cfgBuilder.AddJsonFile(fileName, optional: true);
                }
                if (ext == ConfigurationFileTypes.Xml.GetCode())
                {
                    cfgBuilder.AddXmlFile(fileName, optional: true);
                }

            }



            Cfg = cfgBuilder.Build();
        }
        public ModuleRegistrant(IConfiguration cfg, RegistrantOptions options) : this(cfg)
        {
            RegistrantOptions = options;
        }
        /// <summary>
        /// Based on Configuration with section assemblies. Default registration for repositories.
        /// </summary>
        /// <param name="cfg"></param>
        public ModuleRegistrant(IConfiguration cfg)
        {
            Cfg = cfg;
        }

        /// <summary>
        /// Based on Configuration with section assemblies.
        /// </summary>
        /// <param name="cfg"></param>
        /// <param name="lookFor"></param>
        public ModuleRegistrant(IConfiguration cfg, IList<StringFilter> lookFor) : this(cfg)
        {
            RegistrantOptions.LookFor = lookFor ?? throw new ArgumentNullException(nameof(lookFor), nameof(lookFor) + "should be defined");
        }
        public ModuleRegistrant(IConfiguration cfg, string cfgSection, IList<StringFilter> lookFor) : this(cfg, lookFor)
        {
            RegistrantOptions.CfgSectionName = cfgSection;
        }

        protected IConfiguration Cfg { get; }

        protected override void Load(ContainerBuilder builder)
        {

            try
                {
                    var searchAssemblies = Cfg.GetSection(RegistrantOptions.CfgSectionName).GetChildren().Select(it => it.Value);
                    //TODO:should be a bind here to options
                    foreach (var assembly in searchAssemblies)
                    {
                        foreach (var lookFor in RegistrantOptions.LookFor)
                        {
                            var possiblePath = GetAssemblyName(assembly);
                            switch (lookFor.CompareOperation)
                            {
                                case StringCompareOperation.Prefix:
                                    builder.RegisterAssemblyTypes(Assembly.Load(possiblePath))
                                        .Where(t => t.Name.StartsWith(lookFor.Target))
                                        .AsImplementedInterfaces();
                                    break;
                                case StringCompareOperation.Contains:
                                    builder.RegisterAssemblyTypes(Assembly.Load(possiblePath))
                                        .Where(t => t.Name.Contains(lookFor.Target))
                                        .AsImplementedInterfaces();
                                    break;
                                case StringCompareOperation.Postfix:
                                    builder.RegisterAssemblyTypes(Assembly.Load(possiblePath))
                                        .Where(t => t.Name.EndsWith(lookFor.Target))
                                        .AsImplementedInterfaces();
                                    builder.RegisterAssemblyTypes(Assembly.Load(possiblePath))
                                        .Where(t => t.Name.EndsWith(lookFor.Target))
                                        .AsImplementedInterfaces();
                                    break;
                                default:
                                    throw new NotImplementedException("Currently we don't support the operation you requested.");
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    LogEventManager.Logger.Error(ex.Message, ex);
                    throw;
                }
        }

        private AssemblyName GetAssemblyName(string name)
        {
            var targetPath = SearchUtils.LookupCommonAssemblyStores(name);

            if (string.IsNullOrEmpty(targetPath)) return null;

            AssemblyName assemblyName = null;

#if NETCOREAPP1_0 || NETCOREAPP2_0 || NETCOREAPP2_1
            assemblyName = AssemblyLoadContext.GetAssemblyName(targetPath);
#endif
#if NET452
                if (!targetPath.EndsWith(".dll"))
                    targetPath += ".dll";
                assemblyName = AssemblyName.GetAssemblyName(targetPath);
#endif
                
            return assemblyName;
        }
    }
}
