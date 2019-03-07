using System;

namespace RSignSDK.Models.MasterData
{
    public class StatusCode
    {
        /// <summary>
        /// Uniquely identifies the status code.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Name or description of the status code.
        /// </summary>
        public string Description { get; set; }
    }
}