using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSignSDK.Models
{
    public class ConditionalControlsDetails
    {
        public string ID { get; set; }

        public string EnvelopeID { get; set; }

        public string ControlID { get; set; }

        public string ControllingFieldID { get; set; }

        public string ControllingConditionID { get; set; }

        public string EnvelopeStage { get; set; }

        public string GroupCode { get; set; }

        public bool? IsRequired { get; set; }

        public List<DependentField> DependentFields { get; set; }
    }
}