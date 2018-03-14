using System;
using System.Collections.Generic;

namespace NMS.Models.SiteViewModels
{
    public partial class Site
    {
        public int Idsite { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Domain { get; set; }
        public int? FkNumberFormat { get; set; }
        public int FkCustomer { get; set; }
    }
}
