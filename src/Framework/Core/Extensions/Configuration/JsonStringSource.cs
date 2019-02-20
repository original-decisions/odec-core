using Microsoft.Extensions.Configuration;

namespace odec.Framework.Extensions.Configuration
{
    public class JsonStringSource : IConfigurationSource
    {
        public string SourceString { get; set; }
        /// <summary>
        /// Determines if loading the file is optional.
        /// </summary>
        public bool Optional { get; set; }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
                return new JsonStringProvider(this);
        }
    }
}
