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
                    RecipientEmail = "test.sender.fern@gmail.com"
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
                        Email = "test.sender.fern@gmail.com",
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
                    Subject = "Integration Test Subject"
                });

                Assert.IsNotNull(prepareEnvelopeResponse);
                Assert.AreEqual(prepareEnvelopeResponse.StatusCode, 200);
                Assert.IsNotNull(prepareEnvelopeResponse.Message);
                Assert.IsNotNull(prepareEnvelopeResponse.EnvelopeId);

                // Note: Why do we have to re-send the UserToken? It's part of the HTTP header when you make the call. Seems redundant.
                var sendEnvelopeResponse = sut.SendEnvelope(new SendEnvelopeRequest
                {
                    EnvelopeID = useTemplateResponse.EnvelopeID,
                    UserID = "552CC3B3-7E9F-4473-A804-20E6C1233FFA",//useTemplateResponse.EnvelopeDetails.RecipientList.Single(x => x.RecipientType == "Sender").ID,
                    EnvelopeTypeID = useTemplateResponse.EnvelopeTypeID,
                    Stage = "",
                    UserToken = "igp_N9NpNK8oKT00VTf3Ag4chR0nvwUR8S_BpDdz-2tHAf2R2B8kEoPTq1DpsBmDNum2h4Lx8aVX0SFKI66XVWCFEwJWsJ8epQepM2XulX9QRFA4TMqyuO-prl1ccxL8290zI6NWgrjtAAaOup4hz4iMpnyZeTqYgBoMxLbe9kjd8mBIJ-SflyjvUdgocnxe-dX8GwDXwpmU4a96JcNL0A-bYV2xY8X3X6MNBF31U0VHsIXSrBXdkHnap7km_xyhEQSxLloczeBIhQi91W2yWHNrtO6xxT6GaFKCJbVqf0164K7AC6hxdE55sNm_v8-Ay2I7a4xFV4TE_JFtWUnUNkrOkUNItUK7spY91BN8rHYAD8wI3SM9o44Rf-3-pRGqxU20RG-wXlEbslvDLe1bpD3Wr0En4DUDbcNRlippuarRowwbHP-KkoJUbdLDriNHEVReoPeZUF2snDf87GSburFVjHOPW9EJm6IQ_QGOE-4HWCEIBSaSx7h8rRdDkSAH9I-B9zNCVGQvJ6DqiNZnmF2kUGcaSpKLrldqxAFvOu4"
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