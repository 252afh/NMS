using System;
using System.Collections.Generic;

namespace NMS.Models.NumberTemplateViewModels
{
    public partial class NumberTemplate
    {
        public int IdnumberTemplate { get; set; }
        public int FkNumber { get; set; }
        public int FkTemplate { get; set; }
        public int? Priority { get; set; }
        public int? Active { get; set; }
        public int FkRoutingGroup { get; set; }
    }
}
