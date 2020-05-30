using System;
using LaDanse.Target.Entities.GameData.Core;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.GameData.Characters
{
    public partial class GameCharacter : IBaseEntity<Guid>, ITimeVersionedEntity
    {
        public Guid Id { get; set; }
        
        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }
        
        public string Name { get; set; }
        
        public Guid GameRealmId { get; set; }
        public virtual GameRealm GameRealm { get; set; }
    }
}
