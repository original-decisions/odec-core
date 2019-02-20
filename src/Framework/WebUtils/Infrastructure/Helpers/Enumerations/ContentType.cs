using odec.Framework.Attributes;

namespace odec.Framework.CP.Web.Infrastructure.Helpers.Enumerations
{
    public enum ContentType
    {
        [UniqueCode(Code = "application/json")]
        Json,
        [UniqueCode(Code = "application/x-www-form-urlencoded")]
        Form,
        [UniqueCode(Code = "")]
        File
    }
}