// <copyright file="ReportconfigurationNumber.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Models.ReportConfigurationNumberViewModels
{
    public partial class ReportconfigurationNumber
    {
        public int IdreportconfigurationNumber { get; set; }
        public int FkReportConfiguration { get; set; }
        public int FkNumber { get; set; }
    }
}
