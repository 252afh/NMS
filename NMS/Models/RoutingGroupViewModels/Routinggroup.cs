using System;
using System.Collections.Generic;

namespace NMS.Models.RoutingGroupViewModels
{
    public partial class Routinggroup
    {
        public int IdroutingGroup { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Active { get; set; }
        public int? IsUserGenerated { get; set; }
        public int FkCustomer { get; set; }
        public int Forking { get; set; }
    }
}
