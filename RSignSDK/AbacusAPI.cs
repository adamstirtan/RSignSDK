using RSignSDK.Contracts;
using RSignSDK.Models;
using RSignSDK.Models.Authentication;
using RSignSDK.Models.MasterData;
using System;
using System.Linq;

namespace RSignSDK
{
    public class AbacusAPI
    {
        public AbacusAPI()
        {
        }

        public string DocumentSend(byte[] documentByte, string documentName, string templateName, string recipientEmail, string recipientName, string subject, string body)
        {
            var rsignCredentials = new RSignAPICredentials(
                "aaron.cullen@fernsoftware.com",
                "Whatever1!",
                "OQAxADgAQwBFADYAOQBEA");

            var envelopeId = "";

            using (IRSignAPIInternal sut = new RSignAPI(rsignCredentials))
            {
                var initializeEnvelopeResponse = sut.InitializeEnvelope(new InitializeEnvelopeRequest());

                var templates = sut.GetTemplates();

                var template = templates.SingleOrDefault(x => x.Name == templateName);

                var useTemplateResponse = sut.UseTemplate(new UseTemplateRequest
                {
                    TemplateID = template.ID,
                    DocID = initializeEnvelopeResponse.EnvelopeID
                });

                var uploadLocalDocument = sut.UploadLocalDocument(new UploadLocalDocumentRequest(documentByte)
                {
                    FileName = documentName,
                    EnvelopeID = useTemplateResponse.EnvelopeID,
                    EnvelopeStage = "InitializeUseTemplate"
                });

                var myReq = "";
                var signer = useTemplateResponse.EnvelopeDetails.RecipientList.Where(x => x.RecipientType == "Signer");
                foreach (var recipient in signer)
                {
                    var addUpdateRecipientResponse = sut.AddUpdateRecipient(new AddUpdateRecipientRequest
                    {
                        RecipientID = recipient.ID,
                        EnvelopeID = useTemplateResponse.EnvelopeID,
                        RecipientType = recipient.RecipientTypeID,
                        RecipientName = recipientName,
                        Email = recipientEmail,
                        Order = 1
                    });

                    myReq = addUpdateRecipientResponse.EnvelopeID;
                }

                var prepareEnvelopeResponse = sut.PrepareEnvelope(new PrepareEnvelopeRequest
                {
                    EnvelopeID = myReq,
                    Message = body,
                    Subject = subject
                });

                var sendEnvelopeResponse = sut.SendEnvelope(new SendEnvelopeRequest
                {
                    EnvelopeID = prepareEnvelopeResponse.EnvelopeId,
                    UserID = useTemplateResponse.EnvelopeDetails.RecipientList.Single(x => x.RecipientType == "Sender").ID,
                    EnvelopeTypeID = useTemplateResponse.EnvelopeTypeID
                });

                envelopeId = sendEnvelopeResponse.EnvelopeId;
            }

            return envelopeId;
        }

        public string FileNameSend(string filePath, string documentName, string templateName, string recipientEmail, string recipientName, string subject, string body)
        {
            var rsignCredentials = new RSignAPICredentials(
                "aaron.cullen@fernsoftware.com",
                "Whatever1!",
                "OQAxADgAQwBFADYAOQBEA");

            var envelopeId = "";

            using (IRSignAPIInternal sut = new RSignAPI(rsignCredentials))
            {
                var initializeEnvelopeResponse = sut.InitializeEnvelope(new InitializeEnvelopeRequest());

                var templates = sut.GetTemplates();

                var template = templates.SingleOrDefault(x => x.Name == templateName);

                var useTemplateResponse = sut.UseTemplate(new UseTemplateRequest
                {
                    TemplateID = template.ID,
                    DocID = initializeEnvelopeResponse.EnvelopeID
                });

                var bytesDoc = System.IO.File.ReadAllBytes(filePath);
                var uploadLocalDocument = sut.UploadLocalDocument(new UploadLocalDocumentRequest(bytesDoc)
                {
                    FileName = "RSignTest.pdf",
                    EnvelopeID = useTemplateResponse.EnvelopeID,
                    EnvelopeStage = "InitializeUseTemplate"
                });

                var myReq = "";
                var signer = useTemplateResponse.EnvelopeDetails.RecipientList.Where(x => x.RecipientType == "Signer");
                foreach (var recipient in signer)
                {
                    var addUpdateRecipientResponse = sut.AddUpdateRecipient(new AddUpdateRecipientRequest
                    {
                        RecipientID = recipient.ID,
                        EnvelopeID = useTemplateResponse.EnvelopeID,
                        RecipientType = recipient.RecipientTypeID,
                        RecipientName = recipientName,
                        Email = recipientEmail,
                        Order = 1
                    });

                    myReq = addUpdateRecipientResponse.EnvelopeID;
                }

                var prepareEnvelopeResponse = sut.PrepareEnvelope(new PrepareEnvelopeRequest
                {
                    EnvelopeID = myReq,
                    Message = body,
                    Subject = subject
                });

                var sendEnvelopeResponse = sut.SendEnvelope(new SendEnvelopeRequest
                {
                    EnvelopeID = prepareEnvelopeResponse.EnvelopeId,
                    UserID = useTemplateResponse.EnvelopeDetails.RecipientList.Single(x => x.RecipientType == "Sender").ID,
                    EnvelopeTypeID = useTemplateResponse.EnvelopeTypeID
                });

                envelopeId = sendEnvelopeResponse.EnvelopeId;
            }

            return envelopeId;
        }

        public EnvelopeStatus GetEnvelopeStatus(string envelopeId)
        {
            var rsignCredentials = new RSignAPICredentials(
               "aaron.cullen@fernsoftware.com",
               "Whatever1!",
               "OQAxADgAQwBFADYAOQBEA");

            EnvelopeStatus status = null;

            using (var sut = new RSignAPI(rsignCredentials))
            {
                try
                {
                    status = sut.GetEnvelopeStatuses(envelopeId);
                }
                catch (AuthenticationException aEx)
                {
                    throw aEx;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return status;
        }

        public EnvelopeStatus DownloadSignedContract(string envelopeId)
        {
            var rsignCredentials = new RSignAPICredentials(
               "aaron.cullen@fernsoftware.com",
               "Whatever1!",
               "OQAxADgAQwBFADYAOQBEA");

            EnvelopeStatus status = null;

            using (var sut = new RSignAPI(rsignCredentials))
            {
                try
                {
                    status = sut.GetEnvelopeStatuses(envelopeId);
                }
                catch (AuthenticationException aEx)
                {
                    throw aEx;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return status;
        }
    }
}