using System;

namespace RSignSDK.Models.MasterData
{
    public class TextType
    {
        /// <summary>
        /// Uniquely identifies the text type.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Name or description of the text type.
        /// </summary>
        public string Type { get; set; }
    }
}