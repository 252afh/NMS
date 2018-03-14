// <copyright file="Blocking.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Models.BlockingViewModels
{
    public partial class Blocking
    {
        public int Idblocking { get; set; }
        public string Code { get; set; }
        public string NormalisedCode { get; set; }
        public string Description { get; set; }
        public int FkCustomer { get; set; }
    }
}
