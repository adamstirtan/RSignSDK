using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using RSignSDK.Models;

namespace RSignSDK.Tests
{
    [TestClass]
    public class IntegrationTests : BaseApiTest
    {
        [TestMethod]
        public void SendingEnvelopeTest()
        {
            using (var sut = new RSignAPI(GetCredentials()))
            {
                var initializeEnvelopeResponse = sut.InitializeEnvelope(new InitializeEnvelopeRequest
                {
                    RecipientEmail = "noreply@fernsoftware.com"
                });

                Assert.AreEqual(initializeEnvelopeResponse.StatusCode, 200);
                Assert.IsNotNull(initializeEnvelopeResponse.EnvelopeId);
                Assert.IsNotNull(initializeEnvelopeResponse.Message);
                Assert.IsNotNull(initializeEnvelopeResponse.StatusMessage);

                var templates = sut.GetTemplates();

                var template = templates.SingleOrDefault(x => x.Name == "Integration_Test");

                Assert.IsNotNull(template);

                var useTemplateResponse = sut.UseTemplate(new UseTemplateRequest
                {
                    TemplateID = template.ID,
                    DocID = initializeEnvelopeResponse.EnvelopeId
                });
            }
        }
    }
}