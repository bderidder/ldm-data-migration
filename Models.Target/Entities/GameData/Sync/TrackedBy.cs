using System;
using LaDanse.Target.Entities.GameData.Characters;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.GameData.Sync
{
    public partial class TrackedBy : IBaseEntity<Guid>, ITimeVersionedEntity
    {
        public Guid Id { get; set; }

        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }

        public Guid GameCharacterId { get; set; }
        public virtual GameCharacter GameCharacter { get; set; }
        
        public Guid GameCharacterSourceId { get; set; }
        public virtual GameCharacterSource GameCharacterSource { get; set; }
    }
}
