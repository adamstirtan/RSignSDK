using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSignSDK.Models
{
    public class SignatureControlResponse
    {
        public long StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string Message { get; set; }
        public string EnvelopeId { get; set; }
        public string DocumentId { get; set; }
        public string ControlHtmlID { get; set; }
        public string DocumentContentId { get; set; }
        public SelectControlOptionDetails SelectOptions { get; set; }
    }
}
