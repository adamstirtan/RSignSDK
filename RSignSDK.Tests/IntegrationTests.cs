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
                    UserToken = "FiaLKJzkGYIr3AKZj1AkPfYLtmmY9m9INHCz13caM--fvPDPxgAs-qVnjW-MCAZ-eQxOEx8i3h6Nx9WcBys4O9QfoI3JDPILVtUIu-bVk6c-AtvkM5hvGRlQhKCQuJjGn9ZqNX1WAmjyoRa1yHjVdusfWuGT4DGwTYKQDIpjrP30gxxNyFCDj9aTW17fijrVGE820Sfs3vHBFrilgr872M3Rft6Vrycq4GvCfLXqjO4MXU_Dd3B36f_g0_EVsN-gICzkUxvRYxubVHc7XDd1fKywESahCOGnNw1dVxhFy8F3gCZL8PIlGudFuDf8bYuT0JKX3YhiCfcjFi85qZbaoQOuDyDd9dYuNT2AkVZEGQUf34msJWXdraehbrmhvXMXBKE9-1Gr4CaWjLKUBMhpi55iVD2ljxdEV2HnygVf3Eff1__FJHuBiuyZQ8tX9In8zz6iW_bSG0ZLV64YuOH59xbhKZMwbzErT6oWsruNgsh9BRB3vgfgDBadsi6wzFiGg0mM4plN12ZWdi6PmWjQ16n6Mj07FrNzPFcu7YFEgTc"
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