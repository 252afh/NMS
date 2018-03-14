using System;
using System.Collections.Generic;

namespace NMS.Models.NumberGroupViewModels
{
    public partial class Numbergroup
    {
        public int Idgroup { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FkCustomer { get; set; }
    }
}
