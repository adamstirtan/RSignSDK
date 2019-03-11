using System;

namespace RSignSDK.Models
{
    public class Template
    {
        /// <summary>
        /// Unique identifier for the template.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Internally used RSign hash.
        /// </summary>
        public string HashID { get; set; }

        /// <summary>
        /// Integer which uniquely identifies the template.
        /// </summary>
        public long Code { get; set; }

        /// <summary>
        /// The user-defined name of the template.
        /// </summary>
        public string Name { get; set; }
    }
}