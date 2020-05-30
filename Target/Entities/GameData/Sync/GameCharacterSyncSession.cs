using System;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.GameData.Sync
{
    public partial class GameCharacterSyncSession : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        
        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }
        
        public string Log { get; set; }
        
        public Guid GameCharacterSourceId{ get; set; }
        public virtual GameCharacterSource GameCharacterSource { get; set; }
    }
}
