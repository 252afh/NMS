using System;
using System.Collections.Generic;

namespace NMS.Models.MailboxViewModels
{
    public partial class Mailbox
    {
        public int Idmailbox { get; set; }
        public int? Pin { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int SendEmail { get; set; }
        public int DeleteOpt { get; set; }
        public int Attachment { get; set; }
        public byte[] Audiomessage { get; set; }
        public string Audioname { get; set; }
        public int? Audiosize { get; set; }
        public int FkNumber { get; set; }
        public int FkCustomer { get; set; }
        public int Fax { get; set; }
    }
}
