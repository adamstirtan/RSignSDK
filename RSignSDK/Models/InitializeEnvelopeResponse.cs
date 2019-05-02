namespace RSignSDK.Models
{
    public sealed class InitializeEnvelopeResponse
    {
        public int StatusCode { get; set; }

        public string StatusMessage { get; set; }

        public string Message { get; set; }

        public string EnvelopeId { get; set; }
    }
}