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
        }

        public DateFormat DateFormatID { get; set; }

        public ExpiryType ExpiryType { get; set; }

        public bool PasswordRequiredToSign { get; set; }

        public bool PasswordRequiredToOpen { get; set; }

        public string PasswordToSign { get; set; }

        public string PasswordToOpen { get; set; }

        public bool IsTransparencyDocReq { get; set; }

        public bool IsSignerAttachFileReq { get; set; }
    }
}