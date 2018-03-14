// <copyright file="CarrierNumberException.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Models.CarrierNumberExceptionViewModels
{
    public partial class CarrierNumberException
    {
        public int IdcarrierNumberException { get; set; }
        public int? Priority { get; set; }
        public int? Status { get; set; }
        public int? FkCarrier { get; set; }
        public int? FkExceptionNumber { get; set; }
        public int? FkExceptionLcr { get; set; }
    }
}
