using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSignSDK.Models
{
    public class DownloadSignedContractResponse
    {
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Message { get; set; }
        public string Base64FileData { get; set; }
        public byte[] byteArray { get; set; }
    }
}
