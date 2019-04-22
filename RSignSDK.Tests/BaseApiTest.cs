using RSignSDK.Models.Authentication;

namespace RSignSDK.Tests
{
    public abstract class BaseApiTest
    {
        protected RSignAPICredentials GetCredentials()
        {
            return new RSignAPICredentials(
                "aaron.cullen@fernsoftware.com",
                "Whatever1!",
                "OQAxADgAQwBFADYAOQBEA");
        }
    }
}