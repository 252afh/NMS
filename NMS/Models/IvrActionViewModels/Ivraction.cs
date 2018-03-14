// <copyright file="Ivraction.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

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
