using Microsoft.Extensions.Configuration;

namespace odec.Framework.Extensions.Configuration
{
    /// <summary>
    /// Adds an additional configuration source which is coming from the simple string. 
    /// </summary>
    public class JsonStringSource : IConfigurationSource
    {
        /// <summary>
        /// Source string to be converted to the configuration.
        /// </summary>
        public string SourceString { get; set; }
        /// <summary>
        /// Determines if loading the file is optional.
        /// </summary>
        public bool Optional { get; set; }


        /// <inheritdoc />
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new JsonStringProvider(this);
        }
    }
}
