using System;

namespace RSignSDK.Models.MasterData
{
    public class SettingsKeyConfig
    {
        /// <summary>
        /// Uniquely identifies the setting.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Name or description of the setting.
        /// </summary>
        public Guid Value { get; set; }
    }
}