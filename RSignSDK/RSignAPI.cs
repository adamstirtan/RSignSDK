using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using Newtonsoft.Json;

using RSignSDK.Contracts;
using RSignSDK.Http;
using RSignSDK.Models;
using RSignSDK.Models.Authentication;
using RSignSDK.Models.MasterData;

namespace RSignSDK
{
    /// <summary>
    /// Implementation for accessing RSign API.
    /// </summary>
    public class RSignAPI : IRSignAPI
    {
        /// <summary>
        /// The default date format to use in RSign API calls.
        /// </summary>
        public DateFormat DateFormat { get; set; }

        /// <summary>
        /// The default expiry type to use in RSign API calls.
        /// </summary>
        public ExpiryType ExpiryType { get; set; }

        private bool _isAuthenticated;

        private HashSet<EnvelopeType> _envelopeTypes;

        private readonly RSignHttpClient _httpClient;
        private readonly RSignAPICredentials _credentials;
        private readonly RSignAPIOptions _options;

        private const string ProductionApiUrl = "https://webapi.rsign.com/api/V1/";

        /// <summary>
        /// Constructs RSignAPI with credentials and default options.
        /// </summary>
        /// <param name="credentials">Your RSign API credentials.</param>
        public RSignAPI(RSignAPICredentials credentials)
            : this(credentials, null)
        { }

        /// <summary>
        /// Constructs RSignAPI with credentials and options.
        /// </summary>
        /// <param name="credentials">Your RSign API credentials.</param>
        /// <param name="options">Your custom RSign API options.</param>
        public RSignAPI(RSignAPICredentials credentials, RSignAPIOptions options)
        {
            _credentials = credentials;
            _options = options ?? new RSignAPIOptions
            {
                DateFormat = "EU",
                ExpiryType = "30 Days"
            };

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

                DateFormat = GetDateFormats()
                    .Single(x => _options.DateFormat.Equals(x.Description, StringComparison.InvariantCultureIgnoreCase));

                ExpiryType = GetExpiryTypes()
                    .Single(x => _options.ExpiryType.Equals(x.Description, StringComparison.InvariantCultureIgnoreCase));

                _envelopeTypes = new HashSet<EnvelopeType>(GetEnvelopeTypes());
            }
            else
            {
                throw new AuthenticationException("Invalid RSign API user name or password");
            }
        }

        /// <summary>
        /// Creates a new template.
        /// </summary>
        /// <param name="request">Options for the template to be created.</param>
        /// <returns>The newly created template.</returns>
        public Template CreateTemplate(InitializeTemplateRequest request)
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var response = _httpClient.Get("Template/InitializeTemplate");

            var templateResponse = JsonConvert.DeserializeObject<InitializeTemplateResponse>(response.Content.ReadAsStringAsync().Result);

            // if something went wrong
            // use ID to look up template and return it

            // api call to get template by ID

            var template = JsonConvert.DeserializeObject<Template>(// api call to get template by ID)

            return new Template();
        }

        /// <summary>
        /// Returns the available templates.
        /// </summary>
        /// <returns>The response from the GetRemplates API method, as returned by RSign.</returns>
        public IEnumerable<Template> GetTemplates()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var envelopeType = _envelopeTypes.Single(x => x.Description.Equals("Template", StringComparison.InvariantCultureIgnoreCase));

            var response = _httpClient.Get(string.Format("Template/GetConsumableListForEnvelope/{0}", envelopeType.EnvelopeTypeId));

            var result = new List<Template>();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                result = JsonConvert
                    .DeserializeObject<TemplateList>(response.Content.ReadAsStringAsync().Result)
                    .Templates
                    .ToList();
            }

            return result;
        }

        /// <summary>
        /// Returns the available rules.
        /// </summary>
        /// <returns>The response from the GetRules API method, as returned by RSign.</returns>
        public IEnumerable<Rule> GetRules()
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var envelopeType = _envelopeTypes.Single(x => x.Description.Equals("TemplateRule", StringComparison.InvariantCultureIgnoreCase));

            var response = _httpClient.Get(string.Format("Template/GetConsumableListForEnvelope/{0}", envelopeType.EnvelopeTypeId));

            var result = new List<Rule>();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                result = JsonConvert
                    .DeserializeObject<RuleList>(response.Content.ReadAsStringAsync().Result)
                    .Rules
                    .ToList();
            }

            return result;
        }

        public IEnumerable<Template> InitializeTemplate(Guid ID, string HashID, long Code, string Name)
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var request = new InitializeTemplateRequest
            {
                DateFormatID = new Guid("577d1738-6891-45de-8481-e3353eb6a963"),
                ExpiryTypeID = new Guid("ee01fd0a-b72e-4f62-b434-7081db5bb1db"),
                PasswordRequiredToSign = false,
                PasswordRequiredToOpen = false,
                PasswordToSign = null,
                PasswordToOpen = null,
                IsTransparencyDocReq = false,
                IsSignerAttachFileReq = false,
                IpAddress = "176.35.180.22",
                RecipientEmail = "lorcan.quinn@fernsoftware.com",
                StaticTemplateID = "00000000-0000-0000-0000-000000000000",
                SenderUserId = "00000000-0000-0000-0000-000000000000",
                IsStatic = null,
                IsAttachXMLDataReq = false,
                IsSeparateMultipleDocumentsAfterSigningRequired = false,
                IsConfirmationEmailReq = false,
                IsDisclaimerInCertificate = false,
                AccessAuthenticationType = null,
                AccessAuthenticationPassword = null,
                IsRandomPassword = false,
                IsPasswordMailToSigner = false,
                CultureInfo = "en-us",
                CertificateSignature = null,
            };

            var response = _httpClient
                .Post("Template/InitializeTemplate", JsonConvert.SerializeObject(_credentials));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var authenticationResponse = JsonConvert
                    .DeserializeObject<AuthenticationResponse>(response.Content.ReadAsStringAsync().Result);

                _httpClient.SetAuthenticationToken(authenticationResponse.AuthToken);
                _isAuthenticated = true;

                DateFormat = GetDateFormats()
                    .Single(x => _options.DateFormat.Equals(x.Description, StringComparison.InvariantCultureIgnoreCase));

                ExpiryType = GetExpiryTypes()
                    .Single(x => _options.ExpiryType.Equals(x.Description, StringComparison.InvariantCultureIgnoreCase));

                _envelopeTypes = new HashSet<EnvelopeType>(GetEnvelopeTypes());
            }
            else
            {
                throw new AuthenticationException("Template could not be initialized. Please try again.");
            }

            var template = JsonConvert.DeserializeObject<InitializeTemplateResponse>(new Guid(template.TemplateId));

            //need to pass TemplateCode
        }

        public IEnumerable<Template> UseTemplate(string templateId, string envelopeId)
        {
            if (!_isAuthenticated)
            {
                Authenticate();
            }

            var request = new UseTemplateRequest
            {
                TemplateID = templateId,
                IPAddress = "176.35.180.22",
                DocID = envelopeId //This is EnvelopeId from Initilize Envelope
            };

            var response = _httpClient
                .Post("Envelope/UseTemplate", JsonConvert.SerializeObject(_credentials));

            //needs to extract - EnvelopeTypeId
        }

        public IEnumerable<Template> PrepareEnvelope(string envelopeId, int templateCode, string subject, string message)
        {
            if(!_isAuthenticated)
            {
                Authenticate();
            }

            var request = new PrepareEnvelopeRequest
            {
                DateFormatID = new Guid ("577d1738-6891-45de-8481-e3353eb6a963"),
                ExpiryTypeID = new Guid ("ee01fd0a-b72e-4f62-b434-7081db5bb1db"),
                PasswordRequiredToSign = false,
                PasswordRequiredtoOpen = false,
                PasswordToSign = null,
                PasswordToOpen = null,
                IsTransparencyDocReq = false,
                IsSequenceCheck = false,
                EnvelopeID = envelopeId,
                TemplateCode = templateCode,
                Subject = subject,
                Message = message, //this is the body of the email
                IsSignerAttachFileReq = false,
                IsSeparateMultipleDocumentsAfterSigningRequired = false,
                IsAttachXMLDataReq = false,
                IsDisclaimerInCertificate = false,
                AccessAuthenticationType = null,
                AccessAuthenticationPassword = null,
                IsRandomPassword = false,
                IsPasswordMailToSigner = true,
                AccessAuthType = "3702fe94-d7db-45f4-86d7-8cc4791f7677",
                CultureInfo = "en-us",
                SendReminderIn = 0,
                ThenSendReminderIn = 0,
                SignatureCertificateRequired = true,
                DownloadLinkRequired = true,
                EnvelopeStage = "InitializeEnvelope"
            };

            var response = _httpClient
                .Post("Envelope/PrepareEnvelope", JsonConvert.SerializeObject(_credentials));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var authenticationResponse = JsonConvert
                    .DeserializeObject<AuthenticationResponse>(response.Content.ReadAsStringAsync().Result);

                _httpClient.SetAuthenticationToken(authenticationResponse.AuthToken);
                _isAuthenticated = true;

                DateFormat = GetDateFormats()
                    .Single(x => _options.DateFormat.Equals(x.Description, StringComparison.InvariantCultureIgnoreCase));

                ExpiryType = GetExpiryTypes()
                    .Single(x => _options.ExpiryType.Equals(x.Description, StringComparison.InvariantCultureIgnoreCase));

                _envelopeTypes = new HashSet<EnvelopeType>(GetEnvelopeTypes());
            }
            else
            {
                throw new AuthenticationException("Template could not be initialized. Please try again.");
            }

            var template = JsonConvert.DeserializeObject<PrepareEnvelopeResponse>(template.TemplateId);
        }

        #region Master Data methods

        /// <summary>
        /// Returns the available controls.
        /// </summary>
        /// <returns>The response from the GetControls API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetDateFormats API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetDropDownOptions API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetEnvelopeStatuses API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetEnvelopeTypes API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetExpiryTypes API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetFonts API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetMailTemplates API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetMaxCharacters API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetRecipientTypes API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetRSignStages API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetRuleConfigurations API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetSettingsForTypes API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetSettingsKeyConfigurations API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetShowSettingsTabs API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetSignatureFonts API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetSignatureTypes API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetSignFontStyles API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetStatusCodes API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetTextTypes API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetTimeZones API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetUserConstants API method, as returned by RSign.</returns>
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
        /// <returns>The response from the GetUserTypes API method, as returned by RSign.</returns>
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