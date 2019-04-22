using RSignSDK.Models.MasterData;

namespace RSignSDK.Models
{
    public class AddUpdateRecipientRequest
    {
        internal void SetRecipientType(RecipientType recipientType)
        {
            RecipientType = recipientType.ID.ToString();
        }

        public string EnvelopeID { get; set; }
        public string RecipientType { get; private set; }
        public string RecipientName { get; set; }
        public string Email { get; set; }
        public int Order { get; set; }
        public string RecipientID { get; set; }
    }
}