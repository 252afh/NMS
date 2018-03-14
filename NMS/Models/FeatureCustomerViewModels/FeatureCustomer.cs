using System;
using System.Collections.Generic;

namespace NMS.Models.FeatureCustomerViewModels
{
    public partial class FeatureCustomer
    {
        public int IdfeatureCustomer { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? Quantity { get; set; }
        public int FkFeature { get; set; }
        public int FkCustomer { get; set; }
    }
}
