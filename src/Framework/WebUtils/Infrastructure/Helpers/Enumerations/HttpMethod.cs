using odec.Framework.Attributes;

namespace odec.Framework.CP.Web.Infrastructure.Helpers.Enumerations
{
    /// <summary>
    /// Known http methods. 
    /// </summary>
    public enum HttpMethod
    {
        /// <summary>
        /// Http method POST
        /// </summary>
        [UniqueCode(Code = "POST")]
        Post,
        /// <summary>
        /// Http method GET
        /// </summary>
        [UniqueCode(Code = "GET")]
        Get,
        /// <summary>
        /// Http method PATCH
        /// </summary>
        [UniqueCode(Code = "PATCH")]
        Patch,
        /// <summary>
        /// Http method PUT
        /// </summary>
        [UniqueCode(Code = "PUT")]
        Put,
        /// <summary>
        /// Http method DELETE
        /// </summary>
        [UniqueCode(Code = "DELETE")]
        Delete
    }
}