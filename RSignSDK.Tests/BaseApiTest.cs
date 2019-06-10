using RSignSDK.Models.Authentication;

namespace RSignSDK.Tests
{
    public abstract class BaseApiTest
    {
        private const string EmailId = "";
        private const string Password = "";
        private const string ReferenceKey = "";

        protected RSignAPICredentials GetCredentials()
        {
            return new RSignAPICredentials(EmailId, Password, ReferenceKey);
        }
    }
}