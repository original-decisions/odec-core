using System;
using System.Net;

namespace odec.Framework.CP.Web.Infrastructure.Helpers
{
    public class TokenCredentials:ICredentials
    {
        public string Token { get; set; }
        public string OathType { get; set; }
        public NetworkCredential GetCredential(Uri uri, string authType)
        {
            throw new NotImplementedException();
        }

    }
}