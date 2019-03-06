using System;

namespace RSignSDK.Models.MasterData
{
    public class EnvelopeType : MasterData
    {
        /// <summary>
        /// Uniquely identifies the envelope type.
        /// </summary>
        public Guid EnvelopeTypeId { get; set; }

        /// <summary>
        /// Name or description of the envelope type.
        /// </summary>
        public string Description { get; set; }
    }
}