using System;

namespace RSignSDK.Models.MasterData
{
    public class DateFormat
    {
        /// <summary>
        /// Uniquely identifies the date format.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Name or description of the date format.
        /// </summary>
        public string Description { get; set; }
    }
}