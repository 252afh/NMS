using System;
using System.Collections.Generic;

namespace NMS.Models.ReportConfigurationViewModels
{
    public partial class Reportconfiguration
    {
        public int IdreportConfiguration { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FkUserProfile { get; set; }
        public int FkCustomer { get; set; }
    }
}
