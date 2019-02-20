using System.Collections.Generic;
using odec.Framework.Generic.Utility;
using odec.Framework.Infrastructure.Enumerations;

namespace odec.Framework.Infrastructure.Autofac
{
    public class RegistrantOptions
    {
        public RegistrantOptions()
        {
            InitDefault();
        }
        public string CfgSectionName { get; set; }
        public IList<string> LookupFileNames { get; set; }
        public IList<StringFilter> LookFor { get; set; }
        public IList<ConfigurationFileTypes> CfgLookupTypes { get; set; }

        public void InitDefault()
        {
            LookFor = new List<StringFilter>
            {
                new StringFilter("Repository")
                {
                    CompareOperation = StringCompareOperation.Postfix
                },
                new StringFilter("Export")
                {
                    CompareOperation = StringCompareOperation.Prefix
                },
                new StringFilter("Import")
                {
                    CompareOperation = StringCompareOperation.Prefix
                },
                new StringFilter("Exchange")
                {
                    CompareOperation = StringCompareOperation.Prefix
                }
            };
            LookupFileNames = new List<string>
            {
                "lookupAssemblies.json",
                "lookupAssemblies.xml",
            };
        }

    }
}