using System;

namespace RSignSDK.Models
{
    /// <summary>
    /// A wrapper class for creating a template.
    /// </summary>
    public class InitializeTemplateRequest
    {
        public InitializeTemplateRequest()
        {
            StaticTemplateID = "00000000-0000-0000-0000-000000000000";
            SenderUserId = "00000000-0000-0000-0000-000000000000";
        }

        internal void SetIpAddress(string ipAddress)
        {
            IpAddress = ipAddress;
        }

        /// <summary>
        /// The name of the template.
        /// </summary>
        public string TemplateName { get; set; }

        /// <summary>
        /// The description of the template.
        /// </summary>
        public string TemplateDescription { get; set; }

        /// <summary>
        /// The date format for the template.
        /// </summary>
        public Guid DateFormatID { get; set; }

        /// <summary>
        /// The expiry type for the template.
        /// </summary>
        public Guid ExpiryTypeID { get; set; }

        /// <summary>
        /// Sets whether a password is required to sign the document.
        /// </summary>
        public bool PasswordRequiredToSign { get; set; }

        /// <summary>
        /// Sets whether a password is required to open the document.
        /// </summary>
        public bool PasswordRequiredToOpen { get; set; }

        /// <summary>
        /// Optional password for PasswordRequiredToSign property.
        /// </summary>
        public string PasswordToSign { get; set; }

        /// <summary>
        /// Optional password for PasswordRequiredToOpen property.
        /// </summary>
        public string PasswordToOpen { get; set; }

        /// <summary>
        /// Sets whether a transparent document with all the updated controls will be provided along with the final contract.
        /// </summary>
        public bool IsTransparencyDocReq { get; set; }

        /// <summary>
        /// Sets whether signers will be able to attach documents to the envelope while signing the document.
        /// </summary>
        public bool IsSignerAttachFileReq { get; set; }

        /// <summary>
        /// The IP address of the originating request.
        /// </summary>
        public string IpAddress { get; private set; }

        /// <summary>
        /// The recipient ID.
        /// </summary>
        public string RecipientEmail { get; set; }

        /// <summary>
        /// Status of the envelope signing. Default is false.
        /// </summary>
        public bool IsEnvelopeComplete { get; private set; }

        /// <summary>
        /// Default is 00000000-0000-0000-0000-000000000000.
        /// </summary>
        public string StaticTemplateID { get; set; }

        /// <summary>
        /// Internal use only.
        /// </summary>
        public object ControlCollection { get; private set; }

        /// <summary>
        /// The Sender ID.
        /// </summary>
        public string SenderUserId { get; set; }

        /// <summary>
        /// This will be null.
        /// </summary>
        public string Comment { get; private set; }

        /// <summary>
        /// RSign API treats
        /// </summary>
        public bool? IsStatic { get; set; }

        /// <summary>
        /// Sets whether a XML document with all the updated controls will be provided along with the final contract.
        /// </summary>
        public bool IsAttachXMLDataReq { get; set; }

        /// <summary>
        /// Sets whether the final contract will be a merged PDF document.
        /// </summary>
        public bool IsSeparateMultipleDocumentsAfterSigningRequired { get; set; }

        /// <summary>
        /// The sender will receive an additional confirmation link. The signing process will only be complete once the link is clicked.
        /// </summary>
        public bool IsConfirmationEmailReq { get; set; }

        /// <summary>
        /// The disclaimer created by the sender will be displayed to the signer before they can sign the document.
        /// </summary>
        public bool IsDisclaimerInCertificate { get; set; }

        /// <summary>
        /// Set to null when initializing template.
        /// </summary>
        public object AccessAuthenticationType { get; set; }

        /// <summary>
        /// Set to null when initializing template.
        /// </summary>
        public object AccessAuthenticationPassword { get; set; }

        /// <summary>
        /// Sets whether password is required to access the envelope.
        /// </summary>
        public bool IsRandomPassword { get; set; }

        /// <summary>
        /// Sets whether the password is required to sign the document.
        /// </summary>
        public bool IsPasswordMailToSigner { get; set; }

        /// <summary>
        /// The RSignLanguage description.
        /// </summary>
        public string CultureInfo { get; set; }

        /// <summary>
        /// This will be null while initializing the template.
        /// </summary>
        public object CertificateSignature { get; set; }

        /// <summary>
        /// Sets whether the template can be changed.
        /// </summary>
        public bool IsTemplateEditable { get; set; }

        /// <summary>
        /// This will be null while initialzing the template.
        /// </summary>
        public bool? IsEdited { get; set; }
    }
}