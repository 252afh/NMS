// <copyright file="CarrierCode.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Models.CarrierCodeViewModels
{
    public partial class CarrierCode
    {
        public int IdcarrierCode { get; set; }
        public int? Priority { get; set; }
        public int? Status { get; set; }
        public int FkCarrier { get; set; }
        public int FkCode { get; set; }
        public int? FkLcr { get; set; }
    }
}
