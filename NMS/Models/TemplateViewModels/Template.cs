// <copyright file="Template.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Models.TemplateViewModels
{
    public partial class Template
    {
        public int Idtemplate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FkCustomer { get; set; }
    }
}
