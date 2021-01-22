using System;

namespace LaDanse.Source.Entities.Telemetry
{
    public partial class MailSend
    {
        public int Id { get; set; }
        public DateTime SendOn { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string Subject { get; set; }
    }
}
