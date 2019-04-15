using Newtonsoft.Json;
using RSignSDK.Http;
using RSignSDK.Models;
using RSignSDK.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RSignSDK
{
    public class InitializeTemplate
    {
        private readonly RSignHttpClient _httpClient;
        private readonly RSignAPICredentials _credentials;
        private readonly RSignAPIOptions _options;

        public Task<InitializeTemplateRequest> InitializeTemplates()
        {
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

            return JsonConvert.DeserializeObject<InitializeTemplateResponse>(response);
        }
    }
}
