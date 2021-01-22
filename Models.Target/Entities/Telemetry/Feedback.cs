using System;
using LaDanse.Target.Entities.Identity;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.Telemetry
{
    public partial class Feedback : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public DateTime PostedOn { get; set; }
        public string Content { get; set; }

        public Guid PostedById { get; set; }
        public virtual User PostedBy { get; set; }
    }
}
