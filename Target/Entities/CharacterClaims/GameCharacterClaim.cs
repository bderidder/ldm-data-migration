using System;
using LaDanse.Target.Entities.GameData.Characters;
using LaDanse.Target.Entities.Identity;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.CharacterClaims
{
    public partial class GameCharacterClaim : IBaseEntity<Guid>, ITimeVersionedEntity
    {
        public Guid Id { get; set; }

        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid GameCharacterId { get; set; }
        public virtual GameCharacter GameCharacter { get; set; }
    }
}
