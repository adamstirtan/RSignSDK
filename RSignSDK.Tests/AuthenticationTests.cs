using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RSignSDK.Tests
{
    [TestClass]
    public class AuthenticationTests : BaseApiTest
    {
        [TestMethod]
        public void DefaultDateFormatTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    // Force authentication
                    sut.GetControls();

                    Assert.AreEqual(sut.DateFormat.Description, "EU");
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void CustomDateFormatTest()
        {
            const string actual = "US";

            var options = new RSignAPIOptions
            {
                DateFormat = actual,
                ExpiryType = "30 Days"
            };

            using (var sut = new RSignAPI(GetCredentials(), options))
            {
                try
                {
                    // Force authentication
                    sut.GetControls();

                    Assert.AreEqual(sut.DateFormat.Description, actual);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void DefaultExpiryTypeTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    // Force authentication
                    sut.GetControls();

                    Assert.AreEqual(sut.ExpiryType.Description, "30 Days");
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void CustomExpiryTypeTest()
        {
            const string actual = "2 Days";

            var options = new RSignAPIOptions
            {
                DateFormat = "EU",
                ExpiryType = actual
            };

            using (var sut = new RSignAPI(GetCredentials(), options))
            {
                try
                {
                    // Force authentication
                    sut.GetControls();

                    Assert.AreEqual(sut.ExpiryType.Description, actual);
                }
                catch (AuthenticationException)
                {
                    Assert.Fail();
                }
            }
        }
    }
}