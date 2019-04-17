using System.Collections.Generic;

using Newtonsoft.Json;

namespace RSignSDK.Models
{
    public class DocumentContentDetails
    {
        public string ControlHtmlData { get; set; }

        public string ControlHtmlID { get; set; }

        public string ControlID { get; set; }

        public string DocumentID { get; set; }

        public string GroupName { get; set; }

        public int Height { get; set; }

        public string ID { get; set; }

        public string Label { get; set; }

        public int PageNo { get; set; }

        public int DocumentPageNo { get; set; }

        public string RecipientID { get; set; }

        public bool Required { get; set; }

        public string SenderControlValue { get; set; }

        public int Width { get; set; }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public int ZCoordinate { get; set; }

        public string RecipientName { get; set; }

        public int? MaxLength { get; set; }

        public string TextType { get; set; }

        public string SelectControlOptions { get; set; }

        public string DependentFields { get; set; }

        public int? LeftIndex { get; set; }

        public int? TopIndex { get; set; }

        public ControlStyle ControlStyle { get; set; }

        [JsonProperty(PropertyName = "controlStyleDetails")]
        public List<ControlStyleDetail> ControlStyleDetails { get; set; }
    }
}