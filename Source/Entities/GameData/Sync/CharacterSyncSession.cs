using System;

namespace LaDanse.Source.Entities.GameData.Sync
{
    public partial class CharacterSyncSession
    {
        public Guid Id { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Log { get; set; }
        public Guid CharacterSourceId{ get; set; }

        public virtual CharacterSource CharacterSource { get; set; }
    }
}
