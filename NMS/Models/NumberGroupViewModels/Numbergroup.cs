// <copyright file="Numbergroup.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Models.NumberGroupViewModels
{
    public partial class Numbergroup
    {
        public int Idgroup { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FkCustomer { get; set; }
    }
}
