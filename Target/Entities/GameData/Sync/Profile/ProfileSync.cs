using System;
using LaDanse.Target.Entities.Identity;

namespace LaDanse.Target.Entities.GameData.Sync.Profile
{
    public partial class ProfileSync : GameCharacterSource
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
