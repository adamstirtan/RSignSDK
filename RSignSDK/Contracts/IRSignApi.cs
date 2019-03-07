using System.Collections.Generic;

using RSignSDK.Models.MasterData;

namespace RSignSDK.Contracts
{
    public interface IRSignAPI
    {
        IEnumerable<DateFormat> GetDateFormats();

        IEnumerable<Font> GetFonts();

        IEnumerable<string> GetSignatureFonts();
    }
}