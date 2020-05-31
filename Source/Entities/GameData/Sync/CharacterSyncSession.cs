using System;

namespace LaDanse.Source.Entities.GameData.Sync
{
    public partial class CharacterSyncSession
    {
        public string Id { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Log { get; set; }
        public string CharacterSourceId{ get; set; }

        public virtual CharacterSource CharacterSource { get; set; }
    }
}
