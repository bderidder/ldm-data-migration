using System;
using LaDanse.Target.Entities.Identity;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.Telemetry
{
    public partial class FeatureUse : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public DateTime UsedOn { get; set; }
        public string Feature { get; set; }
        public string RawData { get; set; }

        public Guid? UsedById { get; set; }
        public virtual User UsedBy { get; set; }
    }
}
