using System;
using System.Collections.Generic;

namespace NMS.Models.NumberViewModels
{
    public partial class Number
    {
        public int Idnumber { get; set; }
        public string Number1 { get; set; }
        public string Description { get; set; }
        public int FkCustomer { get; set; }
        public int? FkGroup { get; set; }
        public DateTime? ActiveDate { get; set; }
        public string CustomerDescription { get; set; }
        public DateTime? CeaseDate { get; set; }
    }
}
