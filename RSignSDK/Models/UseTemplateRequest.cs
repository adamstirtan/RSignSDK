namespace RSignSDK.Models
{
    public class UseTemplateRequest
    {
        internal void SetIpAddress(string ipAddress)
        {
            IPAddress = ipAddress;
        }

        public string TemplateID { get; set; }
        public string IPAddress { get; private set; }
        public string DocID { get; set; }
    }
}