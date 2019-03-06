using System;

namespace RSignSDK.Models.MasterData
{
    public class MaxCharacter : MasterData
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