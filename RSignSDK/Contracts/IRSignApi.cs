using System;

using RSignSDK.Models;
using RSignSDK.Models.MasterData;

namespace RSignSDK.Contracts
{
    public interface IRSignAPI : IDisposable
    {
        string Send(byte[] documentByte, string documentName, string templateName, string recipientEmail, string recipientName, string subject, string body);

        string Send(string filePath, string documentName, string templateName, string recipientEmail, string recipientName, string subject, string body);

        EnvelopeStatusResponse GetEnvelopeStatus(string envelopeDisplayCode);

        DownloadSignedContractResponse DownloadSignedContract(string envelopeId);

        bool DeleteFinalContract(string envelopeId);
    }
}