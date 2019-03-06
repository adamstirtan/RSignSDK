using System.Collections.Generic;
using System.Linq;
using System.Net;

using Newtonsoft.Json;

using RSignSDK.Contracts;
using RSignSDK.Http;
using RSignSDK.Models.Authentication;
using RSignSDK.Models.MasterData;

namespace RSignSDK
{
    /// <summary>
    /// Implementation for accessing RSign API.
    /// </summary>
    public class RSignAPI : IRSignAPI
    {
        private bool _isAuthenticated;

        private readonly IHttpClient _httpClient;
        private readonly RSignAPICredentials _credentials;

        private const string ProductionApiUrl = "https://webapi.rsign.com/api/V1/";

        /// <summary>
        /// Constructs RSignAPI with credentials.
        /// </summary>
        /// <param name="credentials"></param>
        public RSignAPI(RSignAPICredentials credentials)
        {
            _credentials = credentials;
            _httpClient = new RSignHttpClient(ProductionApiUrl);
        }

        /// <summary>
        /// Returns the available date formats.
        /// </summary>
        /// <returns>The response from the GetDateFormats API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<DateFormat> GetDateFormats()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/DATEFORMAT");

            return JsonConvert
                .DeserializeObject<MasterDataList<DateFormat>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
        }

        /// <summary>
        /// Returns the available fonts.
        /// </summary>
        /// <returns>The response from the GetFonts API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<Font> GetFonts()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/FONT");

            return JsonConvert
                .DeserializeObject<MasterDataList<Font>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
        }

        private void Authenticate()
        {
            var response = _httpClient
                .Post("Authentication/AuthenticateUser", JsonConvert.SerializeObject(_credentials));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var authenticationResponse = JsonConvert
                    .DeserializeObject<AuthenticationResponse>(response.Content.ReadAsStringAsync().Result);

                _httpClient.SetAuthenticationToken(authenticationResponse.AuthToken);
                _isAuthenticated = true;
            }
            else
            {
                throw new AuthenticationException("Invalid RSign API user name or password");
            }
        }
    }
}