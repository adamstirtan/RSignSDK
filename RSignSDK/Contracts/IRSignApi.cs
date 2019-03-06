using System.Collections.Generic;

using Fern.RSignSDK.Models.MasterData;

namespace RSignSDK.Contracts
{
    public interface IRSignAPI
    {
        IEnumerable<DateFormat> GetDateFormats();

        IEnumerable<Font> GetFonts();
    }
}