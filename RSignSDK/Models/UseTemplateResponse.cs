namespace RSignSDK.Models
{
    public class UseTemplateResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string Message { get; set; }
        public string EnvelopeID { get; set; }
        public int TemplateCode { get; set; }
        public string EnvelopeTypeID { get; set; }
        public EnvelopeDetails EnvelopeDetails { get; set; }
    }
}