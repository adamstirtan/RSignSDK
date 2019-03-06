using RSignSDK.Models.Authentication;

namespace RSignSDK.Tests
{
    public abstract class BaseApiTest
    {
        protected static string EmailId = "";
        protected static string Password = "";
        protected static string ReferenceKey = "";

        protected RSignAPICredentials GetCredentials()
        {
            return new RSignAPICredentials(EmailId, Password, ReferenceKey);
        }
    }
}