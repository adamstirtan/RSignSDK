using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSignSDK.Models
{
    public class SendEnvelopeRequest
    {
        public string EnvelopeID { get; set; }
        public string UserID { get; set; }
        public string EnvelopeTypeID { get; set; }
        public string Stage { set; get; }
        public string UserToken { get; set; }
        public string IpAddress { get; set; }
        public bool? Controls { get; set; }
    }
}
