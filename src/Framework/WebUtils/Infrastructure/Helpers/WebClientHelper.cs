using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using odec.Framework.CP.Web.Infrastructure.Helpers.Enumerations;
using odec.Framework.Extensions;
using HttpMethod = odec.Framework.CP.Web.Infrastructure.Helpers.Enumerations.HttpMethod;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Http.Extensions;
#if net452
using System.Web;
#endif

namespace odec.Framework.CP.Web.Infrastructure.Helpers
{
    public static class WebClientHelper
    {
        //todo: contentTypeDependency
        public static T SendRequest<T>(string requestUrl, IDictionary<string, string> routeParameters,
            IDictionary<string, object> requestParameters = null, HttpMethod httpMethod = HttpMethod.Get,
            ICredentials credentials = null, ContentType contentType = ContentType.Json, AuthenticationHeaders authenticationHeader = AuthenticationHeaders.Basic)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType.Json.GetCode()));
                //Set alternate credentials


                switch (authenticationHeader)
                {
                    case AuthenticationHeaders.Basic:
                        if (credentials != null)
                        {
                            var username = string.Empty;
                            var password = string.Empty;
                            var netCredentials = credentials as NetworkCredential;
                            if (netCredentials != null)
                            {
                                username = netCredentials.UserName;
                                password = netCredentials.Password;
                            }
                            client.DefaultRequestHeaders.Authorization =
                                new AuthenticationHeaderValue(AuthenticationHeaders.Basic.GetCode(),
                                    Convert.ToBase64String(
                                        Encoding.ASCII.GetBytes(
                                            string.Format("{0}:{1}", username, password))));
                        }
                        break;
                    case AuthenticationHeaders.Bearer:
                        if (credentials != null)
                        {
                            var token = string.Empty;
                            var tokenCredentials = credentials as TokenCredentials;
                            if (tokenCredentials != null)
                                token = tokenCredentials.Token;
                            client.DefaultRequestHeaders.Authorization =
                                new AuthenticationHeaderValue(AuthenticationHeaders.Basic.GetCode(),
                                    Convert.ToBase64String(
                                        Encoding.ASCII.GetBytes(token)));
                        }
                        break;
                }


                var responseBody = string.Empty;
                var urlBuilder = new UriBuilder(requestUrl);
#if net452
var collection
#endif
                var collection = QueryHelpers.ParseQuery(urlBuilder.Query);
                foreach (var parameter in routeParameters)
                    collection[parameter.Key] = parameter.Value;
                StringContent content;
                String contentString = string.Empty;
                switch (contentType)
                {
                    case ContentType.Json:

                        contentString = JsonConvert.SerializeObject(requestParameters);
                        break;
                    case ContentType.Form:
                        contentString = requestParameters.ToKeyValuePairsString();
                        break;
                }
                switch (httpMethod)
                {
                    case HttpMethod.Get:


                        var items = collection.SelectMany(x => x.Value, (col, value) => new KeyValuePair<string, string>(col.Key, value)).ToList();
                        var qb = new QueryBuilder(items);
                        requestUrl = urlBuilder + qb.ToQueryString().Value;
                        using (var response = client.GetAsync(requestUrl).Result)
                        {
                            response.EnsureSuccessStatusCode();
                            responseBody = response.Content.ReadAsStringAsync().Result;
                        }

                        break;
                    case HttpMethod.Post:
                        content = new StringContent(contentString,
                            Encoding.UTF8,
                            contentType.GetCode());
                        using (var response = client.PostAsync(requestUrl, content).Result)
                        {
                            response.EnsureSuccessStatusCode();
                            responseBody = response.Content.ReadAsStringAsync().Result;
                        }
                        break;
                    case HttpMethod.Patch:
                        throw new NotImplementedException("");
                    case HttpMethod.Put:
                        content = new StringContent(contentString,
                            Encoding.UTF8,
                            contentType.GetCode());
                        using (var response = client.PutAsync(requestUrl, content).Result)
                        {
                            response.EnsureSuccessStatusCode();
                            responseBody = response.Content.ReadAsStringAsync().Result;
                        }
                        break;
                    case HttpMethod.Delete:
                        content = new StringContent(contentString,
                            Encoding.UTF8,
                            contentType.GetCode());
                        using (var response = client.DeleteAsync(requestUrl).Result)
                        {
                            response.EnsureSuccessStatusCode();
                            responseBody = response.Content.ReadAsStringAsync().Result;
                        }
                        break;
                }
                return JsonConvert.DeserializeObject<T>(responseBody);
            }
        }

    }

}
