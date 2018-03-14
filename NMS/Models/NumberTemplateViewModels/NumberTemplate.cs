// <copyright file="NumberTemplate.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Models.NumberTemplateViewModels
{
    public partial class NumberTemplate
    {
        public int IdnumberTemplate { get; set; }
        public int FkNumber { get; set; }
        public int FkTemplate { get; set; }
        public int? Priority { get; set; }
        public int? Active { get; set; }
        public int FkRoutingGroup { get; set; }
    }
}
