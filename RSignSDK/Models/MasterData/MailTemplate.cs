using System;

namespace RSignSDK.Models.MasterData
{
    public class MailTemplate : MasterData
    {
        /// <summary>
        /// Uniquely identifies the mail template.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Name or description of the mail template.
        /// </summary>
        public string Name { get; set; }
    }
}