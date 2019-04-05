using odec.Framework.Attributes;

namespace odec.Framework.Infrastructure
{
    /// <summary>
    /// File types for the application config
    /// </summary>
    public enum ConfigurationFileTypes
    {
        /// <summary>
        /// Json file type
        /// </summary>
        [UniqueCode(Code = "json")]
        Json = 0,
        /// <summary>
        /// Xml file type
        /// </summary>
        [UniqueCode(Code = "xml")]
        Xml = 1,
        /// <summary>
        /// Plain text with a separator type.
        /// </summary>
        [UniqueCode(Code = "plain")]
        PlainTxtWithSeparator = 2
    }
}