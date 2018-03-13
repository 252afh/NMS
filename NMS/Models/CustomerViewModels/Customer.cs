using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NMS.Models.CustomerViewModels
{
    public partial class Customer
    {
        [DisplayName("Customer Id")]
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Routing number")]
        public string RoutingNumber { get; set; }

        [DisplayName("Billing number")]
        public string DefaultBillingNumber { get; set; }

        [DisplayName("Geo")]
        public int NonGeo { get; set; }

        [DisplayName("Exception Lcr")]
        public int? FkExceptionLcr { get; set; }

        [DisplayName("Block anonymous")]
        public int BlockAnonymous { get; set; }

        [DisplayName("Customer Column")]
        public string Customercol { get; set; }
    }
}
