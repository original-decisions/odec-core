using odec.Framework.Generic.Utility;
using odec.Framework.Infrastructure.Enumerations;
using System.Collections.Generic;

namespace odec.Framework.Infrastructure.Autofac
{
    /// <summary>
    /// Registrant options object. It is basically used for the autofac config registration.
    /// </summary>
    public class RegistrantOptions
    {
        /// <summary>
        /// Default constructor inits the defaults:
        /// <code>
        /// LookFor = new List&lt;StringFilter&gt;
        /// {
        /// new StringFilter("Repository")
        /// {
        /// CompareOperation = StringCompareOperation.Postfix
        /// },
        /// new StringFilter("Export")
        /// {
        /// CompareOperation = StringCompareOperation.Prefix
        /// },
        /// new StringFilter("Import")
        /// {
        /// CompareOperation = StringCompareOperation.Prefix
        /// },
        /// new StringFilter("Exchange")
        /// {
        /// CompareOperation = StringCompareOperation.Prefix
        /// }
        /// };
        /// LookupFileNames = new List&lt;string&gt;
        /// {
        /// "lookupAssemblies.json",
        /// "lookupAssemblies.xml",
        /// };
        /// </code>
        /// </summary>
        public RegistrantOptions()
        {
            InitDefault();
        }
        /// <summary>
        /// Specifies config section name where to search.
        /// </summary>
        public string CfgSectionName { get; set; }
        /// <summary>
        /// Which files should we lookup for the assembly names to plug in the runtime.
        /// </summary>
        public IList<string> LookupFileNames { get; set; }
        /// <summary>
        /// Which values we are looking for. It is set as the <see cref="StringFilter"/> list.
        /// </summary>
        public IList<StringFilter> LookFor { get; set; }

        /// <summary>
        /// Which Configuration types we are looking for. (not used currently)
        /// </summary>
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