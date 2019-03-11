using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using RSignSDK.Contracts;

namespace RSignSDK.Tests
{
    [TestClass]
    public class RulesTests : BaseApiTest
    {
        [TestMethod]
        public void GetTemplatesTest()
        {
            using (IRSignAPI sut = new RSignAPI(GetCredentials()))
            {
                try
                {
                    var list = sut.GetRules();

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