using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RSignSDK.Tests
{
    [TestClass]
    public class TemplatesTests : BaseApiTest
    {
        [TestMethod]
        public void GetTemplatesTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetTemplates();

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
}