﻿using System;
using System.Collections.Generic;

namespace NMS.Models.AnnouncementViewModels
{
    public partial class Announcement
    {
        public int Idannouncement { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Audiomessage { get; set; }
        public string Audioname { get; set; }
        public int Audiosize { get; set; }
        public int Repeattimes { get; set; }
        public int FkCustomer { get; set; }
        public int? FkContact { get; set; }
        public int InProgress { get; set; }
    }
}
