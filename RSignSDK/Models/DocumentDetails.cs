using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace RSignSDK.Models
{
    public class DocumentDetails
    {
        public string ID { get; set; }

        public string DocumentName { get; set; }

        public string EnvelopeID { get; set; }

        public int Order { get; set; }

        public DateTime UploadedDateTime { get; set; }

        public long? FileSize { get; set; }

        [JsonProperty(PropertyName = "documentContentDetails")]
        public List<DocumentContentDetails> DocumentContentDetails { get; set; }
    }
}