// <copyright file="FeatureCustomer.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Models.FeatureCustomerViewModels
{
    using System;

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
