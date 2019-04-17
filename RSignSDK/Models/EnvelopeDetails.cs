using System;

namespace RSignSDK.Models
{
    public class EnvelopeDetails
    {
        public string EnvelopeID { get; set; }
        public string EnvelopeCode { get; set; }
        public string UserID { get; set; }
        public string DateFormat { get; set; }
        public string DateFormatID { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDatetTime { get; set; }
        public bool PasswordReqdToOpen { get; set; }
        public bool PasswordReqdToSign { get; set; }
        public string PasswordToOpen { get; set; }
        public string PasswordToSign { get; set; }
        public int RemainderDays { get; set; }
        public int ReminderRepeatDays { get; set; }
        public string SigningCertificateName { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Location { get; set; }
        public string DocumentHash { get; set; }
        public bool IsActive { get; set; }
        public bool IsEnvelope { get; set; }
        public string ExpiryType { get; set; }
        public string ExpiryTypeID { get; set; }
        public string StatusID { get; set; }
        public int TemplateCode { get; set; }
        public bool SignatureCertificateRequired { get; set; }
        public bool DownloadLinkOnManageRequired { get; set; }
        public string RoleList { get; set; }
        public string EDisplayCode { get; set; }
        public string PasswordKey { get; set; }
        public string PasswordKeySize { get; set; }
        public bool IsTransperancyDocRequired { get; set; }
        public bool IsTemplateDeleted { get; set; }
        public bool IsTemplateEditable { get; set; }
        public bool IsEnvelopePrepare { get; set; }
        public bool IsEnvelopeComplete { get; set; }
        public string TemplateName { get; set; }
        public string TemplateDescription { get; set; }
        public bool? IsDraft { get; set; }
        public bool? IsDraftDeleted { get; set; }
        public bool? IsDraftSend { get; set; }
        public string CultureInfo { get; set; }
        public bool IsSequenceCheck { get; set; }
        public bool IsTemplateShared { get; set; }
        public string EnvelopeStage { get; set; }
        public string EnvelopJson { get; set; }
        public string EnvelopeTypeId { get; set; }
        public bool IsSignerAttachFileReq { get; set; }
        public bool? IsStatic { get; set; }
        public bool IsAttachXMLDataReq { get; set; }
        public bool IsSeparateMultipleDocumentsAfterSigningRequired { get; set; }
        public string AccessAuthenticationType { get; set; }
        public string AccessAuthenticationPassword { get; set; }
        public bool IsRandomPassword { get; set; }
        public bool IsPasswordMailToSigner { get; set; }
        public string AccessAuthType { get; set; }
        public bool IsEdited { get; set; }
        public string PostSigningLandingPage { get; set; }

        public DocumentDetails DocumentDetails { get; set; }
        public RecipientList RecipientList { get; set; }
    }
}