using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NMS.Models.NumberViewModels
{
    public partial class Number
    {
        public int Id { get; set; }

        [DisplayName("Number")]
        public string Number1 { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Customer")]
        public int FkCustomer { get; set; }

        [DisplayName("Group")]
        public int? FkGroup { get; set; }

        [DisplayName("Date Activated")]
        public DateTime? ActiveDate { get; set; }

        [DisplayName("Customer description")]
        public string CustomerDescription { get; set; }

        [DisplayName("End Date")]
        public DateTime? CeaseDate { get; set; }
    }
}
