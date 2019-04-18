namespace RSignSDK.Models
{
    public class AddUpdateReceipientResponse
    {
        public string EnvelopeID { get; set; }
        public string RecipientType { get; set; }
        public string RecipientName { get; set; }
        public string Email { get; set; }
        public int Order { get; set; }
        public string RecipientID { get; set; }
    }
}