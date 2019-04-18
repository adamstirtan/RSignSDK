using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSignSDK.Models;
using System.Linq;

namespace RSignSDK.Tests
{
    [TestClass]
    public class IntegrationTests : BaseApiTest
    {
        [TestMethod]
        public void SendingEnvelopeTest()
        {
            //using (var sut = new RSignAPI(GetCredentials()))
            //{
            //    var initializeEnvelopeResponse = sut.InitializeEnvelope(new InitializeEnvelopeRequest
            //    {
            //    });

            //    var templates = sut.GetTemplates();
            //    var template = templates.Where(x => x.Name == "integration_test")

            //    Assert.AreEqual(initializeEnvelopeResponse.StatusCode, "200");

            //    sut.UseTemplate(new UseTemplateRequest
            //    {
            //        TemplateID
            //    })
            //}
        }
    }
}