using odec.Framework.Attributes;

namespace odec.Framework.CP.Web.Infrastructure.Helpers.Enumerations
{
    /// <summary>
    /// Common Authentication header names for the web development 
    /// </summary>
    public enum AuthenticationHeaders
    {
        /// <summary>
        /// Basic authentication header.
        /// Is used for the simple authentication which is transferring login and password to the server side from the client.
        /// </summary>
        [UniqueCode(Code = "Basic")]
        Basic,
        /// <summary>
        /// Bearer authentication. It is token based authentication which is based on client retrieving the token by different flows and
        /// then reusing it to query the server/api requests with it. Tokens usually have a limited lifetime. 
        /// </summary>
        [UniqueCode(Code = "Bearer")]
        Bearer
    }
}
