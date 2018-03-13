using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NMS.Models.CustomLcrModels
{
    public partial class CustomLcr
    {
        [DisplayName("Custom LCR ID")]
        public int IdCustomLcr { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
    }
}
