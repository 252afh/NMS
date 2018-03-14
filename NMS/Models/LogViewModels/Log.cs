// <copyright file="Log.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Models.LogViewModels
{
    using System;

    public partial class Log
    {
        public long Idlog { get; set; }
        public string Action { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string Table { get; set; }
        public string Attribute { get; set; }
        public string NewValue { get; set; }
        public int? IdModified { get; set; }
        public int FkUser { get; set; }
    }
}
