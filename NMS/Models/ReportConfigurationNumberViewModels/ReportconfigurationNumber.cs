using System;
using System.Collections.Generic;

namespace NMS.Models.ReportConfigurationNumberViewModels
{
    public partial class ReportconfigurationNumber
    {
        public int IdreportconfigurationNumber { get; set; }
        public int FkReportConfiguration { get; set; }
        public int FkNumber { get; set; }
    }
}
