using System;

namespace RSignSDK.Models
{
    public class Recipient
    {
        public string ID { get; set; }

        public string EnvelopeID { get; set; }

        public string StatusID { get; set; }

        public string RecipientName { get; set; }

        public string OldRecipient { get; set; }

        public string OldEmail { get; set; }

        public string RecipientTypeID { get; set; }

        public string EmailID { get; set; }

        public string Order { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string RecipientType { get; set; }

        public string IpAddress { get; set; }
    }
}