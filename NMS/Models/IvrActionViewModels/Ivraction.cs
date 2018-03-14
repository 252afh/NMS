using System;
using System.Collections.Generic;

namespace NMS.Models.IvrActionViewModels
{
    public partial class Ivraction
    {
        public int Idivraction { get; set; }
        public int Digit { get; set; }
        public int FkIvr { get; set; }
        public int? FkIvrDest { get; set; }
        public int? FkContactDest { get; set; }
        public int? FkAnnouncementDest { get; set; }
        public int? FkMailboxDest { get; set; }
        public int VoicemailMain { get; set; }
    }
}
