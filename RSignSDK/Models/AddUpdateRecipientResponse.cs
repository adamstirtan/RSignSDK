namespace RSignSDK.Models
{
    public class AddUpdateRecipientResponse
    {
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string Message { get; set; }
        public string EnvelopeID { get; set; }
        public string RecipientID { get; set; }
        public string RecipientName { get; set; }
    }
}