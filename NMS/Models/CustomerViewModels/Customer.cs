using System;
using System.Collections.Generic;

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
