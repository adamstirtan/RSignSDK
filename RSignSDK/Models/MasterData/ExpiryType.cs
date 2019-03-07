using System;

namespace RSignSDK.Models.MasterData
{
    public class ExpiryType
    {
        /// <summary>
        /// Uniquely identifies the expiry type.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Name or description of the expiry type.
        /// </summary>
        public string Description { get; set; }
    }
}