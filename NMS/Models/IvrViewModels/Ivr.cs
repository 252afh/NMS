using System;
using System.Collections.Generic;

namespace NMS.Models.IvrViewModels
{
    public partial class Ivr
    {
        public int Idivr { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Audiomessage { get; set; }
        public string Audioname { get; set; }
        public int? Audiosize { get; set; }
        public int? Repeattimes { get; set; }
        public int Timeout { get; set; }
        public int FkCustomer { get; set; }
    }
}
