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
                    RecipientEmail = "lorcan.quinn@fernsoftware.com"
                });

                Assert.IsNotNull(initializeEnvelopeResponse);
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

                Assert.IsNotNull(useTemplateResponse);
                Assert.AreEqual(useTemplateResponse.StatusCode, 200);
                Assert.IsNotNull(useTemplateResponse.StatusMessage);
                Assert.IsNotNull(useTemplateResponse.EnvelopeID);
                Assert.IsNotNull(useTemplateResponse.TemplateCode);
                Assert.IsNotNull(useTemplateResponse.EnvelopeTypeID);

                Assert.IsNotNull(useTemplateResponse.EnvelopeDetails);
                Assert.IsNotNull(useTemplateResponse.EnvelopeDetails.EnvelopeID);

                Assert.IsNotNull(useTemplateResponse.EnvelopeDetails.DocumentDetails);
                Assert.AreEqual(1, useTemplateResponse.EnvelopeDetails.DocumentDetails.Count);

                foreach (var recipient in useTemplateResponse.EnvelopeDetails.RecipientList.Where(x => x.RecipientType == "Signer"))
                {
                    var addUpdateRecipientResponse = sut.AddUpdateRecipient(new AddUpdateRecipientRequest
                    {
                        RecipientID = recipient.ID,
                        EnvelopeID = useTemplateResponse.EnvelopeID,
                        RecipientType = recipient.RecipientTypeID,
                        RecipientName = "Fern Tester",
                        Email = "lorcan.quinn@fernsoftware.com",
                        Order = 1
                    });

                    Assert.IsNotNull(addUpdateRecipientResponse);
                    Assert.AreEqual(addUpdateRecipientResponse.StatusCode, 200);
                    Assert.IsNotNull(addUpdateRecipientResponse.StatusMessage);
                    Assert.IsNotNull(addUpdateRecipientResponse.EnvelopeID);
                    Assert.IsNotNull(addUpdateRecipientResponse.RecipientID);
                    Assert.IsNotNull(addUpdateRecipientResponse.RecipientName);
                }

                var prepareEnvelopeResponse = sut.PrepareEnvelope(new PrepareEnvelopeRequest
                {
                    EnvelopeID = useTemplateResponse.EnvelopeID,
                    Message = "Integration Test Message",
                    Subject = "Integration Test Subject",
                    TemplateCode = useTemplateResponse.TemplateCode
                });

                Assert.IsNotNull(prepareEnvelopeResponse);
                Assert.AreEqual(prepareEnvelopeResponse.StatusCode, 200);
                Assert.IsNotNull(prepareEnvelopeResponse.Message);
                Assert.IsNotNull(prepareEnvelopeResponse.EnvelopeId);

                var sendEnvelopeResponse = sut.SendEnvelope(new SendEnvelopeRequest
                {
                    EnvelopeID = prepareEnvelopeResponse.EnvelopeId,
                    UserID = useTemplateResponse.EnvelopeDetails.RecipientList.Single(x => x.RecipientType == "Sender").ID,
                    EnvelopeTypeID = useTemplateResponse.EnvelopeTypeID,
                    Stage = "",
                    UserToken = "N4mcy0P1jgdX4ZqZJVSrbaR4tunHSwFkVcVoJoDGsCWdusqgBHyzTWLjqyAXT7UBmSg3ZwToWFhY97LNCKMgAKRrhNmWTpX4uGP7eDg9aOZBrbsRKW_qUJZd-javZ2nkawFnRVwmWjbP1kGhOgVwaKOxa1V074dFfY_emMFEXSmEqaXlUkcTOQEdctLILrSxnN-X56-Z3PME3sQlmOWn6I2wAeTS8tWbdIN3uUsvd-JIh3rBcVz-76KYiQL-Y5FuhCDaDCC4L0ilaye2tn5h3iGg0CXd-PZARz7ANiLOnLpFed3V9G2fQSK6V89sleQZQWwQ1Mfbbzy6s_dADSBFlcwAqDIu762z-lOBZCtLNmqibuaxCHxrieJjoThhsV2yFRlUPm8fZXjD9wW0JmtvKxjeHUccwu-1m23jKwT4xcBqnnPhl9yTqrprK9va65N5EG4BMW9aeWqR6Bt6938zOXZT7QA-cJYlXNZzI3iatBref_0hXlMX75ODugmhbHwelz7w3iBNsfIuks4t6EXq7dTE_1-Ei8xGYzvHakOTVZA"
                });

                Assert.IsNotNull(sendEnvelopeResponse);
                Assert.IsNotNull(sendEnvelopeResponse.EnvelopeCode);
                Assert.AreEqual(sendEnvelopeResponse.StatusCode, 200);
                Assert.IsNotNull(sendEnvelopeResponse.StatusMessage);
                Assert.IsNotNull(sendEnvelopeResponse.Message);
                Assert.IsNotNull(sendEnvelopeResponse.EnvelopeId);
            }
        }
    }
}