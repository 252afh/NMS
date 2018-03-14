// <copyright file="Reportconfiguration.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

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
