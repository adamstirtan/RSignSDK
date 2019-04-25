namespace RSignSDK.Models
{
    public sealed class PrepareEnvelopeRequest
    {
        public PrepareEnvelopeRequest()
        {
            PasswordRequiredToSign = false;
            PasswordRequiredtoOpen = false;
            PasswordToSign = null;
            PasswordToOpen = null;
            IsTransparencyDocReq = false;
            IsSequenceCheck = false;
            TemplateCode = 0;
            IsSignerAttachFileReq = false;
            IsSeparateMultipleDocumentsAfterSigningRequired = false;
            IsAttachXMLDataReq = false;
            IsDisclaimerInCertificate = false;
            AccessAuthenticationType = false;
            AccessAuthenticationPassword = false;
            IsRandomPassword = false;
            IsPasswordMailToSigner = true;
            CultureInfo = System.Globalization.CultureInfo.CurrentCulture.ToString();
            SendReminderIn = 0;
            ThenSendReminderIn = 0;
            SignatureCertificateRequired = true;
            DownloadLinkRequired = true;
            EnvelopeStage = "InitializeUseRule";
        }

        public string DateFormatID { get; set; }

        public string ExpiryTypeID { get; set; }

        public bool PasswordRequiredToSign { get; set; }

        public bool PasswordRequiredtoOpen { get; set; }

        public bool? PasswordToSign { get; set; }

        public bool? PasswordToOpen { get; set; }

        public bool IsTransparencyDocReq { get; set; }

        public bool IsSequenceCheck { get; set; }

        public string EnvelopeID { get; set; }//EnvelopeID from InitializeEnvelope

        public int TemplateCode { get; set; }//This will be set as zero. When envelope is crated from template, this is updated with the template code

        public string Subject { get; set; }//This will be the subject line of the email

        public string Message { get; set; } //This will be the Message body text of the email

        public bool IsSignerAttachFileReq { get; set; }

        public bool IsSeparateMultipleDocumentsAfterSigningRequired { get; set; }

        public bool IsAttachXMLDataReq { get; set; }

        public bool IsDisclaimerInCertificate { get; set; }

        public bool? AccessAuthenticationType { get; set; }

        public bool? AccessAuthenticationPassword { get; set; }

        public bool IsRandomPassword { get; set; }

        public bool IsPasswordMailToSigner { get; set; }

        public string AccessAuthType { get; set; }

        public string CultureInfo { get; set; }

        public int SendReminderIn { get; set; }

        public int ThenSendReminderIn { get; set; }

        public bool SignatureCertificateRequired { get; set; }

        public bool DownloadLinkRequired { get; set; }

        public string EnvelopeStage { get; set; }//RSIGN DOCS STATE - This will be always set as “InitializeEnvelope”?
    }
}