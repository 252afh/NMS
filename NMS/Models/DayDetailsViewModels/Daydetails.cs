using System;
using System.Collections.Generic;

namespace NMS.Models.DayDetailsViewModels
{
    public partial class Daydetails
    {
        public int IddayDetails { get; set; }
        public string Day { get; set; }
        public TimeSpan? TimeFrom { get; set; }
        public TimeSpan? TimeTo { get; set; }
        public int? Status { get; set; }
        public int FkPeriod { get; set; }
    }
}
