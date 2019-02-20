using odec.Framework.Attributes;

namespace odec.Framework.CP.Web.Infrastructure.Helpers.Enumerations
{
    public enum AuthenticationHeaders
    {
        [UniqueCode(Code = "Basic")]
        Basic,
        [UniqueCode(Code = "Bearer")]
        Bearer
    }
}
