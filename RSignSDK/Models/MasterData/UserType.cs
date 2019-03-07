using System;

namespace RSignSDK.Models.MasterData
{
    public class UserType
    {
        /// <summary>
        /// Uniquely identifies the user type.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Name or description of the user type.
        /// </summary>
        public Guid Value { get; set; }
    }
}