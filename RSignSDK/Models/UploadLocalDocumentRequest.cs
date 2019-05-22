using System;

namespace RSignSDK.Models
{
    public class UploadLocalDocumentRequest
    {
        public UploadLocalDocumentRequest(byte[] bytes)
        {
            DocumentBase64Data = Convert.ToBase64String(bytes);
        }

        public string FileName { get; set; }
        public string EnvelopeID { get; set; }
        public string DocumentBase64Data { get; private set; }
        public string EnvelopeStage { get; set; }
    }
}