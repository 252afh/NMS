using System;
using System.Collections.Generic;

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
