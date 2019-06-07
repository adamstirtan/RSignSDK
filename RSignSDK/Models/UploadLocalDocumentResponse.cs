using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSignSDK.Models
{
    public class UploadLocalDocumentResponse
    {
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string EnvelopeId { get; set; }
        public string DocumentId { get; set; }
        public string FileName { get; set; }
    }
}
