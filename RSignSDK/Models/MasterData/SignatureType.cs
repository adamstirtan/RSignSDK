using System;

namespace RSignSDK.Models.MasterData
{
    public class SignatureType
    {
        /// <summary>
        /// Uniquely identifies the signature type.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Name or description of the signature type.
        /// </summary>
        public Guid Value { get; set; }
    }
}