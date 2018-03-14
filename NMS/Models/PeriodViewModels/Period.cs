// <copyright file="Period.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Models.PeriodViewModels
{
    using System;

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
