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

        /// <summary>
        /// Returns the available controls.
        /// </summary>
        /// <returns>The response from the GetControls API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<Control> GetControls()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/CONTROLS");

            return JsonConvert
                .DeserializeObject<MasterDataList<Control>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
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
        /// Returns the available drop down options.
        /// </summary>
        /// <returns>The response from the GetDropDownOptions API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<DropDownOption> GetDropDownOptions()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/DROPDOWNOPTION");

            return JsonConvert
                .DeserializeObject<MasterDataList<DropDownOption>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
        }

        /// <summary>
        /// Returns the available envelope statuses.
        /// </summary>
        /// <returns>The response from the GetEnvelopeStatuses API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<EnvelopeStatus> GetEnvelopeStatuses()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/ENVELOPESTATUS");

            return JsonConvert
                .DeserializeObject<MasterDataList<EnvelopeStatus>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
        }

        /// <summary>
        /// Returns the available envelope types.
        /// </summary>
        /// <returns>The response from the GetEnvelopeTypes API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<EnvelopeType> GetEnvelopeTypes()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/ENVELOPETYPE");

            return JsonConvert
                .DeserializeObject<MasterDataList<EnvelopeType>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
        }

        /// <summary>
        /// Returns the available expiry types.
        /// </summary>
        /// <returns>The response from the GetExpiryTypes API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<ExpiryType> GetExpiryTypes()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/EXPIRYTYPE");

            return JsonConvert
                .DeserializeObject<MasterDataList<ExpiryType>>(response.Content.ReadAsStringAsync().Result)
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

        /// <summary>
        /// Returns the available mail templates.
        /// </summary>
        /// <returns>The response from the GetMailTemplates API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<MailTemplate> GetMailTemplates()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/MAILTEMPLATE");

            return JsonConvert
                .DeserializeObject<MasterDataList<MailTemplate>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
        }

        /// <summary>
        /// Returns the available max characters.
        /// </summary>
        /// <returns>The response from the GetMaxCharacters API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<MaxCharacter> GetMaxCharacters()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/MAXCHARACTER");

            return JsonConvert
                .DeserializeObject<MasterDataList<MaxCharacter>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
        }

        /// <summary>
        /// Returns the available recipient types.
        /// </summary>
        /// <returns>The response from the GetRecipientTypes API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<RecipientType> GetRecipientTypes()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/RECIPIENTTYPE");

            return JsonConvert
                .DeserializeObject<MasterDataList<RecipientType>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
        }

        /// <summary>
        /// Returns the available RSign stages.
        /// </summary>
        /// <returns>The response from the GetRSignStages API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<RSignStage> GetRSignStages()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/RSIGNSTAGE");

            return JsonConvert
                .DeserializeObject<MasterDataList<RSignStage>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
        }

        /// <summary>
        /// Returns the available rule configurations.
        /// </summary>
        /// <returns>The response from the GetRuleConfigurations API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<RuleConfiguration> GetRuleConfigurations()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/RULECONFIG");

            return JsonConvert
                .DeserializeObject<MasterDataList<RuleConfiguration>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
        }

        /// <summary>
        /// Returns the available settings for types.
        /// </summary>
        /// <returns>The response from the GetSettingsForTypes API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<SettingsForType> GetSettingsForTypes()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/SETTINGSFORTYPE");

            return JsonConvert
                .DeserializeObject<MasterDataList<SettingsForType>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
        }

        /// <summary>
        /// Returns the available settings key configurations.
        /// </summary>
        /// <returns>The response from the GetSettingsKeyConfigurations API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<SettingsKeyConfiguration> GetSettingsKeyConfigurations()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/SETTINGSKEYCONFIG");

            return JsonConvert
                .DeserializeObject<MasterDataList<SettingsKeyConfiguration>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
        }

        /// <summary>
        /// Returns the available show settings tabs.
        /// </summary>
        /// <returns>The response from the GetShowSettingsTabs API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<ShowSettingsTab> GetShowSettingsTabs()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/SHOWSETTINGSTAB");

            return JsonConvert
                .DeserializeObject<MasterDataList<ShowSettingsTab>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
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

        /// <summary>
        /// Returns the available signature types.
        /// </summary>
        /// <returns>The response from the GetSignatureTypes API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<SignatureType> GetSignatureTypes()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/SIGNATURETYPE");

            return JsonConvert
                .DeserializeObject<MasterDataList<SignatureType>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
        }

        /// <summary>
        /// Returns the available sign font styles.
        /// </summary>
        /// <returns>The response from the GetSignFontStyles API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<SignFontStyle> GetSignFontStyles()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/SIGNFONTSTYLE");

            return JsonConvert
                .DeserializeObject<MasterDataList<SignFontStyle>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
        }

        /// <summary>
        /// Returns the available status codes.
        /// </summary>
        /// <returns>The response from the GetStatusCodes API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<StatusCode> GetStatusCodes()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/STATUSCODE");

            return JsonConvert
                .DeserializeObject<MasterDataList<StatusCode>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
        }

        /// <summary>
        /// Returns the available text types.
        /// </summary>
        /// <returns>The response from the GetTextTypes API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<TextType> GetTextTypes()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/TEXTTYPE");

            return JsonConvert
                .DeserializeObject<MasterDataList<TextType>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
        }

        /// <summary>
        /// Returns the available time zones.
        /// </summary>
        /// <returns>The response from the GetTimeZones API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<Models.MasterData.TimeZone> GetTimeZones()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/TIMEZONE");

            return JsonConvert
                .DeserializeObject<MasterDataList<Models.MasterData.TimeZone>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
        }

        /// <summary>
        /// Returns the available user constants.
        /// </summary>
        /// <returns>The response from the GetUserConstants API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<UserConstant> GetUserConstants()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/USERCONSTANTS");

            return JsonConvert
                .DeserializeObject<MasterDataList<UserConstant>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
        }

        /// <summary>
        /// Returns the available user types.
        /// </summary>
        /// <returns>The response from the GetUserTypes API method, as returned by RPost.</returns>
        /// <exception cref="AuthenticationException">This exception is thrown if the supplied credentials are invalid.</exception>
        public IEnumerable<UserType> GetUserTypes()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Dashboard/GetMasterData/USERTYPE");

            return JsonConvert
                .DeserializeObject<MasterDataList<UserType>>(response.Content.ReadAsStringAsync().Result)
                .MasterList
                .AsEnumerable();
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