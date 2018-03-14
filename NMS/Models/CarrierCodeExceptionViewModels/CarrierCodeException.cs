// <copyright file="CarrierCodeException.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Models.CarrierCodeExceptionViewModels
{
    public partial class CarrierCodeException
    {
        public int IdcarrierCodeException { get; set; }
        public int? Priority { get; set; }
        public int? Status { get; set; }
        public int? FkCarrier { get; set; }
        public int? FkCode { get; set; }
        public int? FkExceptionLcr { get; set; }
    }
}
