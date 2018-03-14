// <copyright file="ReportCustomer.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

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
