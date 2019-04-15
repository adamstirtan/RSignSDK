using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSignSDK.Models
{
    public class UseTemplateResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string Message { get; set; }
        public string EnvelopeId { get; set; }
        public int TemplateCode { get; set; }
        public string EnvelopeTypeId { get; set; }
        public Envelope EnvelopeDetails { get; set; }
    }
}
