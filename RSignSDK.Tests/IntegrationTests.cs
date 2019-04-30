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

                var addUpdateRecipientResponse = sut.AddUpdateRecipient(new AddUpdateRecipientRequest
                {
                    EnvelopeID = useTemplateResponse.EnvelopeID,
                    RecipientName = "Fern Tester",
                    Email = "test.sender.fern@fernsoftware.com",
                    Order = 1
                });

                Assert.IsNotNull(addUpdateRecipientResponse);
                Assert.AreEqual(addUpdateRecipientResponse.StatusCode, 200);
                Assert.IsNotNull(addUpdateRecipientResponse.StatusMessage);
                Assert.IsNotNull(addUpdateRecipientResponse.EnvelopeID);
                Assert.IsNotNull(addUpdateRecipientResponse.RecipientID);
                Assert.IsNotNull(addUpdateRecipientResponse.RecipientName);

                var req = new PrepareEnvelopeRequest
                {
                    EnvelopeID = useTemplateResponse.EnvelopeID,
                    Message = "",
                    Subject = "",
                    TemplateCode = useTemplateResponse.TemplateCode
                };

                var prepareEnvelopeResponse = sut.PrepareEnvelope(req);

                Assert.IsNotNull(prepareEnvelopeResponse);
                Assert.AreEqual(prepareEnvelopeResponse.StatusCode, 200);
                Assert.IsNotNull(prepareEnvelopeResponse.OK);
                Assert.IsNotNull(prepareEnvelopeResponse.Message);
                Assert.IsNotNull(prepareEnvelopeResponse.EnvelopeId);

                var sendEnvelopeResponse = sut.SendEnvelope(new SendEnvelopeRequest
                {
                    EnvelopeID = prepareEnvelopeResponse.EnvelopeId,
                    UserID = "552cc3b3-7e9f-4473-a804-20e6c1233ffa",
                    EnvelopeTypeID = "e6f16aed-8544-4dcc-aeb4-639478761f4a",
                    Stage = "",
                    UserToken = "WQezrImi_xAOW9sg11ACE98Lyosnt6bsiEwvsAUOhefRmWyUqzKxZYufH1-s2gzSE19lcVL4KdsWW7JWQR696LhNTXFC2hAl4S0Mg9s3XccxZcJJJdfR1CmoQQWiO9foJzgBypfNcAUq0920FUMzWLqIeKqAiefxF-hT7M6Ucl-gxfl0V0JQLA4a8baiPYcY4rLDq5S5q75H_XBX5dJXK0VPIYLvbectQIM_6McoDsRuUGu2X6gTPnE6Cjx5z8qQJiozBYXSBA3jawB7IpW7G0Vpmd4Xm4maiqvs84MtxhCMUTLz8rJ2Z7ZSyUPdUSLUoEs9bEfeRUzlDHqy-UccHg7Gp3Ypkky6dgNjf4D8eL0_EEtiu_HX1p7F3OqFhcAPRDwtkYM4tSW0F9__sHwRSrb6SNr3P8sCvR-I5c6YhNuqfbUgqB9vUo_CMq4RMpTQS6lAhMyYv5by-1ghhvbJVUTsQy4PKpgSJkTbZlrIbEZK2SGYwYHztGpwowMXpM6nQoZvWD2bBYiGPFbIGQIfFANGtRsnllJQn2Ttvwwumqk"
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