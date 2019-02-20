using odec.Framework.Attributes;

namespace odec.Framework.Infrastructure
{
    public enum ConfigurationFileTypes
    {
        [UniqueCode(Code = "json")]
        Json = 0,
        [UniqueCode(Code = "xml")]
        Xml = 1,
        [UniqueCode(Code = "plain")]
        PlainTxtWithSeparator = 2
    }
}