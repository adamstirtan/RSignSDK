using RSignSDK.Models.MasterData;

namespace RSignSDK.Models
{
    public sealed class InitializeEnvelopeRequest
    {
        public InitializeEnvelopeRequest()
        {
            PasswordRequiredToSign = false;
            PasswordRequiredToOpen = false;
            IsTransparencyDocReq = true;
            IsSignerAttachFileReq = true;
            IsEnvelopeComplete = false;
            StaticTemplateID = "00000000-0000-0000-0000-000000000000";
            SenderUserID = "00000000-0000-0000-0000-000000000000";
            IsStatic = null;
            IsAttachXMLDataReq = false;
            IsSeparateMultipleDocumentsAfterSigningRequired = false;
            IsConfirmationEmailReq = false;
            IsDisclaimerInCertificate = false;
            IsRandomPassword = false;
        }

        public DateFormat DateFormatID { get; set; }

        public ExpiryType ExpiryTypeID { get; set; }

        public bool PasswordRequiredToSign { get; set; }

        public bool PasswordRequiredToOpen { get; set; }

        public string PasswordToSign { get; set; }

        public string PasswordToOpen { get; set; }

        public bool IsTransparencyDocReq { get; set; }

        public bool IsSignerAttachFileReq { get; set; }

        public string IpAddress { get; set; }

        public string RecipientEmail { get; set; }

        public bool IsEnvelopeComplete { get; set; }

        public string StaticTemplateID { get; set; }

        public string ControlCollection { get; set; }

        public string SenderUserID { get; set; }

        public string Comment { get; set; }

        public bool? IsStatic { get; set; }

        public bool IsAttachXMLDataReq { get; set; }

        public bool IsSeparateMultipleDocumentsAfterSigningRequired { get; set; }

        public bool IsConfirmationEmailReq { get; set; }

        public bool IsDisclaimerInCertificate { get; set; }

        public string AccessAuthenticationType { get; set; }

        public string AccessAuthenticationPassword { get; set; }

        public bool IsRandomPassword { get; set; }

        public bool IsPasswordMailToSigner { get; set; }

        public string AccessTypeAuth { get; set; }

        public string CultureInfo { get; set; }

        public string CertificateSignature { get; set; }
    }
}