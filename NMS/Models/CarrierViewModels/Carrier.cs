// <copyright file="Carrier.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Models.CarrierViewModels
{
    public partial class Carrier
    {
        public int Idcarrier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Domain { get; set; }
        public string RoutingNumber { get; set; }
        public string BillingNumber { get; set; }
        public short? Preference { get; set; }
    }
}
