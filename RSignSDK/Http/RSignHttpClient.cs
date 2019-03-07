using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace RSignSDK.Http
{
    internal sealed class RSignHttpClient : IDisposable
    {
        private readonly HttpClient _httpClient;

        private static readonly string AuthenticationTokenHeader = "AuthToken";

        public RSignHttpClient(string baseUrl)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };

            _httpClient.DefaultRequestHeaders
                .TryAddWithoutValidation("cache-control", "no-cache");

            _httpClient.DefaultRequestHeaders
                .TryAddWithoutValidation("Content-Type", "application/json");
        }

        public bool IsAuthenticated()
        {
            return _httpClient.DefaultRequestHeaders.Any(x => x.Key == AuthenticationTokenHeader);
        }

        public void SetAuthenticationToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Add(AuthenticationTokenHeader, token);
        }

        public HttpResponseMessage Get(string resource)
        {
            return _httpClient.GetAsync(resource).Result;
        }

        public HttpResponseMessage Get(string resource, IDictionary<string, string> parameters)
        {
            return _httpClient.GetAsync(ParseParameters(resource, parameters)).Result;
        }

        public HttpResponseMessage Post(string resource, string body)
        {
            return _httpClient.PostAsync(resource, new StringContent(body, Encoding.UTF8, "application/json")).Result;
        }

        public HttpResponseMessage Put(string resource, string body)
        {
            return _httpClient.PutAsync(resource, new StringContent(body, Encoding.UTF8, "application/json")).Result;
        }

        public HttpResponseMessage DeleteAsync(string resource)
        {
            return _httpClient.DeleteAsync(resource).Result;
        }

        private static string ParseParameters(string resource, IDictionary<string, string> parameters)
        {
            var stringBuilder = new StringBuilder(resource);

            if (parameters.Keys.Count > 0)
            {
                stringBuilder.Append("?");
            }

            foreach (var kvp in parameters)
            {
                stringBuilder.Append($"{kvp.Key}={kvp.Value}&");
            }

            var result = stringBuilder.ToString();

            return result.EndsWith("&") ? result.Substring(0, result.Length - 1) : result;
        }

        public void Dispose()
        {
            if (_httpClient != null)
            {
                _httpClient.Dispose();
            }
        }
    }
}