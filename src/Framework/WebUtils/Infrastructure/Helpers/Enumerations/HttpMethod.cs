using odec.Framework.Attributes;

namespace odec.Framework.CP.Web.Infrastructure.Helpers.Enumerations
{
    public enum HttpMethod
    {
        [UniqueCode(Code = "POST")]
        Post,
        [UniqueCode(Code = "GET")]
        Get,
        [UniqueCode(Code = "PATCH")]
        Patch,
        [UniqueCode(Code = "PUT")]
        Put,
        [UniqueCode(Code = "DELETE")]
        Delete
    }
}