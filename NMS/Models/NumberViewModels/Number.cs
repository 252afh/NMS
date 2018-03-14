// <copyright file="Number.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Models.NumberViewModels
{
    using System;

    public partial class Number
    {
        public int Idnumber { get; set; }
        public string Number1 { get; set; }
        public string Description { get; set; }
        public int FkCustomer { get; set; }
        public int? FkGroup { get; set; }
        public DateTime? ActiveDate { get; set; }
        public string CustomerDescription { get; set; }
        public DateTime? CeaseDate { get; set; }
    }
}
