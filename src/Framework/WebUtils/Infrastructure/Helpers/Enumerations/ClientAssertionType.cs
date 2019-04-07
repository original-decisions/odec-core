using odec.Framework.Attributes;

namespace odec.Framework.CP.Web.Infrastructure.Helpers.Enumerations
{
    /// <summary>
    /// Known assertion types.
    /// </summary>
    public enum ClientAssertionType
    {
        /// <summary>
        /// Jwt Bearer assertion type.
        /// </summary>
        [UniqueCode(Code = "urn:ietf:params:oauth:client-assertion-type:jwt-bearer")]
        JwtBearer

    }
}