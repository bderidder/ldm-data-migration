using System;
using LaDanse.Source.Entities.Identity;

namespace LaDanse.Source.Entities.Queues
{
    public partial class NotificationQueueItem
    {
        public int Id { get; set; }

        public string ActivityType { get; set; }
        public DateTime ActivityOn { get; set; }
        public string RawData { get; set; }
        public DateTime? ProcessedOn { get; set; }

        public int? ActivityById { get; set; }
        public virtual Account ActivityBy { get; set; }
    }
}
