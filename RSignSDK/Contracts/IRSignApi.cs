using System;
using System.Collections.Generic;

namespace RSignSDK.Contracts
{
    public interface IRSignAPI : IDisposable
    {
        bool Send(string templateName, IEnumerable<string> recipients);
    }
}