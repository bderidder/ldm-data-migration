using System;
using LaDanse.Target.Entities.GameData;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.Events
{
    public partial class SignedForGameRole : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public GameRole GameRole { get; set; }

        public Guid SignUpId { get; set; }
        public virtual SignUp SignUp { get; set; }
    }
}
