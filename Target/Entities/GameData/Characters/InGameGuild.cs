using System;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.GameData.Characters
{
    public partial class InGameGuild : ITimeVersionedEntity, IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        
        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }

        public Guid GameCharacterId { get; set; }
        public virtual GameCharacter GameCharacter { get; set; }
        
        public Guid GameGuildId { get; set; }
        public virtual GameGuild GameGuild { get; set; }
        
    }
}
