namespace RSignSDK.Models
{
    public class DownloadSignedContractResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Message { get; set; }
        public string Base64FileData { get; set; }
        public byte[] byteArray { get; set; }
    }
}