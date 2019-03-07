using System;

namespace RSignSDK.Models.MasterData
{
    public class MaxCharacter
    {
        /// <summary>
        /// Uniquely identifies the max character setting.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Name or description of the max character setting.
        /// </summary>
        public string TextLength { get; set; }
    }
}