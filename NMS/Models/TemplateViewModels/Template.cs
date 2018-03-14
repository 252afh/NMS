using System;
using System.Collections.Generic;

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
