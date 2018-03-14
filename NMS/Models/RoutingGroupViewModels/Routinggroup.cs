// <copyright file="Routinggroup.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

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
