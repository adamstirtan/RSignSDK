using System.Collections.Generic;
using System.Net.Http;

namespace RSignSDK.Contracts
{
    internal interface IHttpClient
    {
        void SetAuthenticationToken(string token);

        HttpResponseMessage Get(string resource);

        HttpResponseMessage Get(string resource, IDictionary<string, string> parameters);

        HttpResponseMessage Post(string resource, string body);

        HttpResponseMessage Put(string resource, string body);

        HttpResponseMessage DeleteAsync(string resource);
    }
}