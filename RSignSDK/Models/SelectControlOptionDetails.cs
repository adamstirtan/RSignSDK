using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSignSDK.Models
{
    public class SelectControlOptionDetails
    {
        public Guid DocumentContentID { get; set; }
        public Guid ID { get; set; }
        public string OptionText { get; set; }
        public int Order { get; set; }
    }
}
