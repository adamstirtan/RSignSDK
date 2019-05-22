using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSignSDK.Models
{
    public class UploadLocalDocumentRequest
    {
        public string FileName { get; set; }
        public string EnvelopeID { get; set; }
        public string DocumentBase64Data { get; set; }
        public string EnvelopeStage { get; set; }
    }
}
