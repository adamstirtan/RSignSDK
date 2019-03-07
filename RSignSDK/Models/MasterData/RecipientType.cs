using System;

namespace RSignSDK.Models.MasterData
{
    public class RecipientType
    {
        /// <summary>
        /// Uniquely identifies the recipient type.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Name or description of the recipient type.
        /// </summary>
        public string Description { get; set; }
    }
}