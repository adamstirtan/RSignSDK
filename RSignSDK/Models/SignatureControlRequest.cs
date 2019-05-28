using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSignSDK.Models
{
    public class SignatureControlRequest
    {
        public string ControlID { get; set; }
        public bool? Required { get; set; }
        public Guid RecipientID { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }
        public byte fontSize { get; set; }
        public Guid fontFamilyID { get; set; }
        public bool? Bold { get; set; }
        public bool? Underline { get; set; }
        public bool? Italic { get; set; }
        public string MaxLength { get; set; }
        public string ControlType { get; set; }
        public string Label { get; set; }
        public string GroupName { get; set; }
        public string RadioName { get; set; }
        public string SenderControlValue { get; set; }
        public string IsSubmitConfirmation { get; set; }
        public SelectOption ControlOptions { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int ZCoordinate { get; set; }
        public long Left { get; set; }
        public long Top { get; set; }
        public string ControlHtmlID { get; set; }
        public Guid DocumentContentID { get; set; }
        public Guid DocumentID { get; set; }
        public int PageNo { get; set; }
        public int DocumentPageNo { get; set; }
        public string GlobalEnvelopeID { get; set; }
        public string EnvelopeStage { get; set; }
    }
}
