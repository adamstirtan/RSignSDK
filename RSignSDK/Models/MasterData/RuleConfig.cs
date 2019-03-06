namespace RSignSDK.Models.MasterData
{
    public class RuleConfig : MasterData
    {
        /// <summary>
        /// Uniquely identifies the rule.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Name or description of the rule.
        /// </summary>
        public string RuleText { get; set; }
    }
}