using System;
using System.Collections.Generic;

namespace NMS.Models.GroupTemplateViewModels
{
    public partial class GroupTemplate
    {
        public int IdgroupTemplate { get; set; }
        public int FkGroup { get; set; }
        public int FkTemplate { get; set; }
        public int? Priority { get; set; }
        public int? Active { get; set; }
        public int? FkRoutingGroup { get; set; }
    }
}
