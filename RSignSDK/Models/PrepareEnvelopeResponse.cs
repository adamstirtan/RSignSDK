using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSignSDK.Models
{
    public class PrepareEnvelopeResponse
    {
        public int StatusCode { get; set; }
        public string OK { get; set; }
        public string Message { get; set; }
        public string EnvelopeId { get; set; }
    }
}
