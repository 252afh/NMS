// <copyright file="Voicemessages.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Models.VoiceMessagesViewModels
{
    public partial class Voicemessages
    {
        public int Id { get; set; }
        public int Msgnum { get; set; }
        public string Dir { get; set; }
        public string Context { get; set; }
        public string Macrocontext { get; set; }
        public string Callerid { get; set; }
        public string Origtime { get; set; }
        public string Duration { get; set; }
        public string Flag { get; set; }
        public string Mailboxuser { get; set; }
        public string Mailboxcontext { get; set; }
        public string MsgId { get; set; }
        public byte[] Recording { get; set; }
    }
}
