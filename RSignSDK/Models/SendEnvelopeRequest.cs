using Newtonsoft.Json;

namespace RSignSDK.Models
{
    public class SendEnvelopeRequest
    {
        internal void SetIpAddress(string ipAddress)
        {
            IpAddress = ipAddress;
        }

        public string EnvelopeID { get; set; }

        [JsonProperty(PropertyName = "UserId")]
        public string UserID { get; set; }

        public string EnvelopeTypeID { get; set; }

        public string Stage { set; get; }

        public string UserToken { get; set; }

        public string IpAddress { get; private set; }
    }
}