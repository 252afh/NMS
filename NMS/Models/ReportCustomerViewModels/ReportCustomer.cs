using System;
using System.Collections.Generic;

namespace NMS.Models.ReportCustomerViewModels
{
    public partial class ReportCustomer
    {
        public int IdreportCustomer { get; set; }
        public string Frequency { get; set; }
        public int Status { get; set; }
        public string Email { get; set; }
        public int FkCustomer { get; set; }
        public int FkReport { get; set; }
        public int? FkReportConfiguration { get; set; }
    }
}
