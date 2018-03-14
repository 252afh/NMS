// <copyright file="Customer.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Models.CustomerViewModels
{
    public partial class Customer
    {
        public int Idcustomer { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RoutingNumber { get; set; }
        public string DefaultBillingNumber { get; set; }
        public int NonGeo { get; set; }
        public int? FkExceptionLcr { get; set; }
        public int BlockAnonymous { get; set; }
        public string Customercol { get; set; }
    }
}
