using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSignSDK.Models
{
    public class SendEnvelopeResponse
    {
        public string EnvelopeCode { get; set; }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string Message { get; set; }
        public string EnvelopeId { get; set; }

        //something about “TransparencyChangeMessage = (null) ?
    }
}
