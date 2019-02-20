using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using odec.Framework.Logging;

namespace odec.Framework.Infrastructure
{
    /// <summary>
    /// Connection Manager
    /// </summary>
    public static class ConnectionManager
    {
        private static string[] commonAppSetNames = new[]
        {
            "appsettings.json",
            "app.config.json",
            "app.config",
            "app.config.xml",
            "web.config.json",
            "web.config.xml",
            "web.config",
            "appsetting.xml"
        };
        private static IConfiguration cfg;
        
        public static void Init(string basePath = null, IList<string> cfgs = null)
        {
            var builder = new ConfigurationBuilder();
            var dir = basePath ?? Directory.GetCurrentDirectory();
            builder.SetBasePath(dir);
            if (cfgs != null && cfgs.Count > 0)
            {
                foreach (var config in cfgs)
                {
                    var ext = Path.GetExtension(config);
                    switch (ext)
                    {
                        case "json":
                            builder.AddJsonFile(config);
                            break;
                        default:
                            builder.AddXmlFile(config);
                            break;
                    }

                }
            }
            foreach (var config in commonAppSetNames)
            {
                if (!File.Exists(dir + config)) continue;
                var ext = Path.GetExtension(config);
                switch (ext)
                {
                    case "json":
                        builder.AddJsonFile(config);
                        break;
                    default:
                        builder.AddXmlFile(config);
                        break;
                }
            }
            
            cfg = builder.AddEnvironmentVariables().Build();

        }



        /// <summary>
        /// Main application connection string
        /// </summary>
        public static string MainConnection
        {
            get
            {
                try
                {
                    if (cfg == null)
                        Init();
                    return cfg.GetSection("ConnectionStrings")["MainConnection"].ToString();
                }
                catch (Exception ex)
                {
                    LogEventManager.Logger.Error(ex.Message, ex);
                    return "MainConnection";
                    throw;
                }
            }
        }


        /// <summary>
        /// Test  application connection string
        /// </summary>
        public static string TestConnection
        {
            get
            {
                if (cfg == null)
                    Init();
                return cfg.GetSection("ConnectionStrings")["TestConnection"].ToString();
            }

        }

        /// <summary>
        /// Log application connection string
        /// </summary>
        public static string LogConnection
        {
            get
            {
                if (cfg == null)
                    Init();
                return cfg.GetSection("ConnectionStrings")["LogConnection"].ToString();
            }

        }

        /// <summary>
        /// Application connection string for reports
        /// </summary>
        public static string ReportConnection
        {
            get
            {
                if (cfg == null)
                    Init();
                return cfg.GetSection("ConnectionStrings")["ReportConnection"].ToString();
            }
        }


    }
}
