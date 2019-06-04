using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RSignSDK.Contracts;
using RSignSDK.Models;

namespace RSignSDK.Tests
{
    [TestClass]
    public class IntegrationTests : BaseApiTest
    {
        [TestMethod]
        public void PublicContractSendTest()
        {
            using (IRSignAPI sut = new RSignAPI(GetCredentials()))
            {
                var result = sut.Send("Integration_Test", new List<string>
                {
                    "adam.stirtan@fernsoftware.com",
                    "lorcan.quinn@fernsoftware.com"
                });

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void InternalContractSendTest()
        {
            using (IRSignAPIInternal sut = new RSignAPI(GetCredentials()))
            {

                var initializeEnvelopeResponse = sut.InitializeEnvelope(new InitializeEnvelopeRequest());

                Assert.IsNotNull(initializeEnvelopeResponse);
                Assert.AreEqual(initializeEnvelopeResponse.StatusCode, 200);
                Assert.IsNotNull(initializeEnvelopeResponse.EnvelopeID);
                Assert.IsNotNull(initializeEnvelopeResponse.Message);
                Assert.IsNotNull(initializeEnvelopeResponse.StatusMessage);

                var templates = sut.GetTemplates();

                var template = templates.SingleOrDefault(x => x.Name == "Template_Test");

                Assert.IsNotNull(template);

                var useTemplateResponse = sut.UseTemplate(new UseTemplateRequest
                {
                    TemplateID = template.ID,
                    DocID = initializeEnvelopeResponse.EnvelopeID
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

                var bytesDoc = System.IO.File.ReadAllBytes(@"C:\Users\Lorcan\Desktop\RSignTest.pdf");
                var uploadLocalDocument = sut.UploadLocalDocument(new UploadLocalDocumentRequest(bytesDoc)
                {
                    FileName = "RSignTest.pdf",
                    EnvelopeID = useTemplateResponse.EnvelopeID,
                    EnvelopeStage = "InitializeUseTemplate"
                });

                Assert.IsNotNull(uploadLocalDocument);
                Assert.IsNotNull(uploadLocalDocument.StatusMessage);
                Assert.IsNotNull(uploadLocalDocument.EnvelopeId);
                Assert.IsNotNull(uploadLocalDocument.DocumentId);
                Assert.IsNotNull(uploadLocalDocument.FileName);

                var myReq = "";
                var signer = useTemplateResponse.EnvelopeDetails.RecipientList.Where(x => x.RecipientType == "Signer");
                foreach (var recipient in signer)
                {
                    var addUpdateRecipientResponse = sut.AddUpdateRecipient(new AddUpdateRecipientRequest
                    {
                        RecipientID = recipient.ID,
                        EnvelopeID = useTemplateResponse.EnvelopeID,
                        RecipientType = recipient.RecipientTypeID,
                        RecipientName = "Recipient",
                        Email = "test.sender.fern@gmail.com",
                        Order = 1
                    });

                    Assert.IsNotNull(addUpdateRecipientResponse);
                    Assert.AreEqual(addUpdateRecipientResponse.StatusCode, 200);
                    Assert.IsNotNull(addUpdateRecipientResponse.StatusMessage);
                    Assert.IsNotNull(addUpdateRecipientResponse.EnvelopeID);
                    myReq = addUpdateRecipientResponse.EnvelopeID;
                    Assert.IsNotNull(addUpdateRecipientResponse.RecipientID);
                    Assert.IsNotNull(addUpdateRecipientResponse.RecipientName);
                }

                var prepareEnvelopeResponse = sut.PrepareEnvelope(new PrepareEnvelopeRequest
                {
                    EnvelopeID = myReq,
                    Message = "No pdf attached to test for the UploadLocalDocument method",
                    Subject = "Upload Local Document test"
                });

                Assert.IsNotNull(prepareEnvelopeResponse);
                Assert.AreEqual(prepareEnvelopeResponse.StatusCode, 200);
                Assert.IsNotNull(prepareEnvelopeResponse.Message);
                Assert.IsNotNull(prepareEnvelopeResponse.EnvelopeId);

                var sendEnvelopeResponse = sut.SendEnvelope(new SendEnvelopeRequest
                {
                    EnvelopeID = prepareEnvelopeResponse.EnvelopeId,
                    UserID = useTemplateResponse.EnvelopeDetails.RecipientList.Single(x => x.RecipientType == "Sender").ID,
                    EnvelopeTypeID = useTemplateResponse.EnvelopeTypeID
                });

                Assert.IsNotNull(sendEnvelopeResponse);
                Assert.IsNotNull(sendEnvelopeResponse.EnvelopeCode);
                Assert.AreEqual(sendEnvelopeResponse.StatusCode, 200);
                Assert.IsNotNull(sendEnvelopeResponse.StatusMessage);
                Assert.IsNotNull(sendEnvelopeResponse.Message);
                Assert.IsNotNull(sendEnvelopeResponse.EnvelopeId);

                var request = useTemplateResponse.EnvelopeDetails.EDisplayCode;

                var getEnvelopeStatusResponse = sut.GetEnvelopeStatus(request);

                Assert.IsNotNull(getEnvelopeStatusResponse.StatusMessage);
                Assert.IsNotNull(getEnvelopeStatusResponse.EnvelopeID);
                Assert.IsNotNull(getEnvelopeStatusResponse.Message);
                Assert.IsNotNull(getEnvelopeStatusResponse.EnvelopeDetails);

                var aaaa = "15240bd6-ec5a-4262-be7b-3efaf9ce547b";

                var downloadSignedContract = sut.DownloadSignedContract(aaaa);

                Assert.IsNotNull(downloadSignedContract.StatusMessage);
                Assert.IsNotNull(downloadSignedContract.FileName);
                Assert.IsNotNull(downloadSignedContract.FilePath);
                Assert.IsNotNull(downloadSignedContract.Message);
                Assert.IsNotNull(downloadSignedContract.Base64FileData);


            }
        }
    }
}