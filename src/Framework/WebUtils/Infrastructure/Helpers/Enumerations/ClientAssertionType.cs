using odec.Framework.Attributes;

namespace odec.Framework.CP.Web.Infrastructure.Helpers.Enumerations
{
    public enum ClientAssertionType
    {
        [UniqueCode(Code = "urn:ietf:params:oauth:client-assertion-type:jwt-bearer")]
        GwtBearer

    }
}