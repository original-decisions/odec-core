using odec.Framework.Attributes;

namespace odec.Framework.CP.Web.Infrastructure.Helpers.Enumerations
{
    /// <summary>
    /// Known content types to easy out the life.
    /// </summary>
    public enum ContentType
    {
        /// <summary>
        /// Application json type which you specify as the server request type
        /// </summary>
        [UniqueCode(Code = "application/json")]
        Json,
        /// <summary>
        /// Form type which you specify as the server request type
        /// </summary>
        [UniqueCode(Code = "application/x-www-form-urlencoded")]
        Form,
        /// <summary>
        /// File based type. (currently not set)
        /// </summary>
        [UniqueCode(Code = "")]
        File
    }
}