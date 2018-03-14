// <copyright file="Daydetails.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Models.DayDetailsViewModels
{
    using System;

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
