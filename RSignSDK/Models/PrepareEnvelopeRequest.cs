using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSignSDK.Models
{
    public class PrepareEnvelopeRequest
    {
        public Guid DateFormatID { get; set; }
        public Guid ExpiryTypeID { get; set; }
        public bool PasswordRequiredToSign { get; set; }
        public bool PasswordRequiredtoOpen { get; set; }
        public bool? PasswordToSign { get; set; }
        public bool? PasswordToOpen { get; set; }
        public bool IsTransparencyDocReq { get; set; }
        public bool IsSequenceCheck { get; set; }
        public string EnvelopeID { get; set; }
        public int TemplateCode { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
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
        public long SendReminderIn { get; set; }
        public long ThenSendReminderIn { get; set; }
        public bool SignatureCertificateRequired { get; set; }
        public bool DownloadLinkRequired { get; set; }
        public string EnvelopeStage { get; set; }
    }
}
