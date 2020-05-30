using System;
using LaDanse.Target.Entities.Identity;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.Settings
{
    public partial class FeatureToggle : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Feature { get; set; }
        public bool Toggle { get; set; }

        public Guid ToggleForId { get; set; }
        public virtual User ToggleFor { get; set; }
    }
}
