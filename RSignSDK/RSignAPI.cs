using System;
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
    public class RSignAPI : IRSignAPI, IDisposable
    {
        private bool _isAuthenticated;

        private readonly RSignHttpClient _httpClient;
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

        #region Master Data methods

        public IEnumerable<Control> GetControls()
        {
            throw new System.NotImplementedException();
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

        public IEnumerable<DropDownOption> GetDropDownOptions()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EnvelopeStatus> GetEnvelopeStatuses()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EnvelopeType> GetEnvelopeTypes()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ExpiryType> GetExpiryTypes()
        {
            throw new System.NotImplementedException();
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

        public IEnumerable<MailTemplate> GetMailTemplates()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<MaxCharacter> GetMaxCharacters()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<RecipientType> GetRecipientTypes()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<RSignStage> GetRSignStages()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<RuleConfig> GetRuleConfigs()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SettingsForType> GetSettingsForTypes()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SettingsKeyConfig> GetSettingsKeyConfigs()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ShowSettingsTab> GetShowSettingsTabs()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns the available signature fonts.
        /// </summary>
        /// <returns>The response from the GetSignatureFonts API method, as returned by RPost.</returns>
        /// /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<string> GetSignatureFonts()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/SIGNATUREFONT");

            return JsonConvert
                .DeserializeObject<MasterDataList<string>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
        }

        public IEnumerable<SignatureType> GetSignatureTypes()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SignFontStyle> GetSignFontStyles()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<StatusCode> GetStatusCodes()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TextType> GetTextTypes()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Models.MasterData.TimeZone> GetTimeZones()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserConstant> GetUserConstants()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserType> GetUserTypes()
        {
            throw new System.NotImplementedException();
        }

        #endregion Master Data methods

        public void Dispose()
        {
            if (_httpClient != null)
            {
                _httpClient.Dispose();
            }
        }
    }
}