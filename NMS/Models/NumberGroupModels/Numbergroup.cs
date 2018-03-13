using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NMS.Models.NumberGroupModels
{
    public partial class Numbergroup
    {
        [DisplayName("Number group Id")]
        public int Idgroup { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Customer")]
        public int FkCustomer { get; set; }
    }
}
