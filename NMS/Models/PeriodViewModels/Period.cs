using System;
using System.Collections.Generic;

namespace NMS.Models.PeriodViewModels
{
    public partial class Period
    {
        public int Idperiod { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan? TimeTo { get; set; }
        public string Frequency { get; set; }
        public string Day { get; set; }
        public int? Status { get; set; }
        public int FkTemplate { get; set; }
    }
}
