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
        public object PasswordToOpen { get; set; }
        public object PasswordToSign { get; set; }
        public int RemainderDays { get; set; }
        public int ReminderRepeatDays { get; set; }
        public string SigningCertificateName { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public object Location { get; set; }
        public object DocumentHash { get; set; }
        public bool IsActive { get; set; }
        public bool IsEnvelope { get; set; }
        public string ExpiryType { get; set; }
        public string ExpiryTypeID { get; set; }
        public string StatusID { get; set; }
        public int TemplateCode { get; set; }
        public bool SignatureCertificateRequired { get; set; }
        public bool DownloadLinkOnManageRequired { get; set; }

        //public List<DocumentDetail> DocumentDetails { get; set; }
        //public List<RecipientList> RecipientList { get; set; }
        public object RoleList { get; set; }

        public string EDisplayCode { get; set; }
        public object PasswordKey { get; set; }
        public object PasswordKeySize { get; set; }
        public bool IsTransperancyDocRequired { get; set; }
        public bool IsTemplateDeleted { get; set; }
        public bool IsTemplateEditable { get; set; }
        public bool IsEnvelopePrepare { get; set; }
        public bool IsEnvelopeComplete { get; set; }
        public object TemplateName { get; set; }
        public object TemplateDescription { get; set; }
        public object IsDraft { get; set; }
        public object IsDraftDeleted { get; set; }
        public object IsDraftSend { get; set; }
        public string CultureInfo { get; set; }
        public bool IsSequenceCheck { get; set; }
        public bool IsTemplateShared { get; set; }
        public object EnvelopeStage { get; set; }
        public object EnvelopJson { get; set; }
        public object EnvelopeTypeId { get; set; }
        public bool IsSignerAttachFileReq { get; set; }
        public object IsStatic { get; set; }
        public bool IsAttachXMLDataReq { get; set; }
        public bool IsSeparateMultipleDocumentsAfterSigningRequired { get; set; }
        public object AccessAuthenticationType { get; set; }
        public object AccessAuthenticationPassword { get; set; }
        public bool IsRandomPassword { get; set; }
        public bool IsPasswordMailToSigner { get; set; }
        public string AccessAuthType { get; set; }
        public bool IsEdited { get; set; }
        public object PostSigningLandingPage { get; set; }
    }
}