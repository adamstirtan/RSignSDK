using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RSignSDK.Tests.MasterData
{
    [TestClass]
    public class MasterDataTests : BaseApiTest
    {
        [TestMethod]
        public void GetDateFormatsTest()
        {
            var sut = new RSignAPI(GetCredentials());

            try
            {
                var list = sut.GetDateFormats();

                Assert.IsNotNull(list);
                Assert.AreNotEqual(list.Count(), 0);
            }
            catch (AuthenticationException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void GetFontsTest()
        {
            var sut = new RSignAPI(GetCredentials());

            try
            {
                var list = sut.GetFonts();

                Assert.IsNotNull(list);
                Assert.AreNotEqual(list.Count(), 0);
            }
            catch (AuthenticationException)
            {
                Assert.Fail();
            }
        }
    }
}