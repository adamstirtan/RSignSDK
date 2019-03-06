namespace RSignSDK.Models.Authentication
{
    internal sealed class AuthenticationResponse
    {
        public string AuthMessage { get; set; }
        public string AuthToken { get; set; }
        public string EmailId { get; set; }
    }
}