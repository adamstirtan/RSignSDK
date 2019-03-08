using RSignSDK.Models.MasterData;

namespace RSignSDK
{
    internal sealed class DefaultRSignAPIOptions : RSignAPIOptions
    {
        public DefaultRSignAPIOptions()
        {
            DefaultDateFormat = new DateFormat
            {
                Description = "EU"
            };

            DefaultExpiryType = new ExpiryType
            {
                Description = "30 Days"
            };
        }
    }
}