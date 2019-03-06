namespace RSignSDK.Models.MasterData
{
    public class Font : MasterData
    {
        /// <summary>
        /// Uniquely identifies the font.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Name or description of the font family.
        /// </summary>
        public string FontFamily { get; set; }
    }
}