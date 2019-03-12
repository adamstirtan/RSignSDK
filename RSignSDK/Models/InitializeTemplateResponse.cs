namespace RSignSDK.Models
{
    internal class InitializeTemplateResponse
    {
        public long TemplateCode { get; set; }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string Message { get; set; }
        public string TemplateId { get; set; }
    }
}