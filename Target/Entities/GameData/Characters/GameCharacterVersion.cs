using System;
using LaDanse.Target.Entities.GameData.Core;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.GameData.Characters
{
    public partial class GameCharacterVersion : IBaseEntity<Guid>, ITimeVersionedEntity
    {
        public Guid Id { get; set; }
        
        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }
        
        public short Level { get; set; }
        
        public Guid GameCharacterId { get; set; }
        public virtual GameCharacter GameCharacter { get; set; }
        
        public Guid GameClassId { get; set; }
        public virtual GameClass GameClass { get; set; }
        
        public Guid GameRaceId { get; set; }
        public virtual GameRace GameRace { get; set; }
    }
}
