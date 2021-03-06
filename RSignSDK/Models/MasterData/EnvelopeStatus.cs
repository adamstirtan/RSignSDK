﻿using System.Collections.Generic;

namespace RSignSDK.Models.MasterData
{
    public class EnvelopeStatus
    {
        /// <summary>
        /// Gives a brief discription of the status of the envelope.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Unique identifier for the envelope.
        /// </summary>
        public string EnvelopeID { get; set; }

        /// <summary>
        /// In depth description of content within the envelope.
        /// </summary>
        public List<EnvelopeDetails> EnvelopeDetails { get; set; }
    }
}