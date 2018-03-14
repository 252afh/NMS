using System;
using System.Collections.Generic;

namespace NMS.Models.RoutingViewModels
{
    public partial class Routing
    {
        public int Idrouting { get; set; }
        public int? Priority { get; set; }
        public int? RingingTime { get; set; }
        public int? FkContact { get; set; }
        public int? FkSite { get; set; }
        public int? Active { get; set; }
        public int? FkRoutingGroup { get; set; }
        public int HuntBusy { get; set; }
        public int? FkAnnouncement { get; set; }
        public int? FkIvr { get; set; }
        public int? FkMailbox { get; set; }
        public int VoicemailMain { get; set; }
    }
}
