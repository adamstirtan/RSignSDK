using System.IO;
using System.Linq;

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
                var sendFilePath = sut.SendFilePath(@"C:\Users\Lorcan\Documents\Rmail\Contacts.pdf", "Contacts.pdf", "Template_Test", "test.sender.fern@gmail.com", "Lorcan Quinn", "SendFilepath Test 10-06", "This is a test for sending file path");
                Assert.IsNotNull(sendFilePath);

                var documentByte = File.ReadAllBytes(@"C:\Users\Lorcan\Documents\Rmail\Contacts.pdf"); // NOTE: Assuming that we already will have the byte array of the document
                var sendByteDocument = sut.SendByteDocument(documentByte, "Contacts.pdf", "Template_Test", "test.sender.fern@gmail.com", "Lorcan Quinn", "SendFilepath Test 10-06", "This is a test for sending file path");
                Assert.IsNotNull(sendByteDocument);

                var getEnvelopeStatus = sut.GetEnvelopeStatus("23395529-2607-AADE-9697-DDEB");
                Assert.IsNotNull(getEnvelopeStatus);

                var downloadSignedContract = sut.DownloadSignedContract("23395529-2607-AADE-9697-DDEB");
                Assert.IsNotNull(downloadSignedContract);
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

                var bytesDoc = File.ReadAllBytes(@"C:\Users\Lorcan\Desktop\RSignTest.pdf");
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

                //var request = useTemplateResponse.EnvelopeDetails.EDisplayCode;

                //var getEnvelopeStatusResponse = sut.GetEnvelopeStatus(request);

                //Assert.IsNotNull(getEnvelopeStatusResponse.StatusMessage);
                //Assert.IsNotNull(getEnvelopeStatusResponse.EnvelopeID);
                //Assert.IsNotNull(getEnvelopeStatusResponse.Message);
                //Assert.IsNotNull(getEnvelopeStatusResponse.EnvelopeDetails);

                //var aaaa = "15240bd6-ec5a-4262-be7b-3efaf9ce547b";

                //var downloadSignedContract = sut.DownloadSignedContract(aaaa);

                //byte[] bytes = Convert.FromBase64String(downloadSignedContract.Base64FileData);

                //FileStream stream = new FileStream(@"C:\Users\Lorcan\Documents\Rmail\Contracts.pdf", FileMode.CreateNew);

                //BinaryWriter writer = new BinaryWriter(stream);
                //writer.Write(bytes, 0, bytes.Length);
                //writer.Close();

                //Assert.IsNotNull(downloadSignedContract.StatusMessage);
                //Assert.IsNotNull(downloadSignedContract.FileName);
                //Assert.IsNotNull(downloadSignedContract.FilePath);
                //Assert.IsNotNull(downloadSignedContract.Message);
                //Assert.IsNotNull(downloadSignedContract.Base64FileData);

                //var delete = "cad9c0cc-d045-45f3-9063-f59af387fd1d";

                //var deleteFinalContract = sut.DeleteFinalContract(delete);

                //Assert.IsNotNull(deleteFinalContract.StatusCode);
                //Assert.IsNotNull(deleteFinalContract.StatusMessage);
                //Assert.IsNotNull(deleteFinalContract.Message);
            }
        }
    }
}