using System;
using System.Collections.Generic;

namespace NMS.Models.BarringViewModels
{
    public partial class Barring
    {
        public int Idbarring { get; set; }
        public string Code { get; set; }
        public string NormalisedCode { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int? FkCustomer { get; set; }
    }
}
