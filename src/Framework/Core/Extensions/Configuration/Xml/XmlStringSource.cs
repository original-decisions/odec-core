using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace odec.Framework.Extensions.Configuration.Xml
{
    public class XmlStringSource:IConfigurationSource
    {
        public string SourceString { get; set; }
        /// <summary>
        /// Determines if loading the file is optional.
        /// </summary>
        public bool Optional { get; set; }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new XmlStringProvider(this);
        }
    }
}
