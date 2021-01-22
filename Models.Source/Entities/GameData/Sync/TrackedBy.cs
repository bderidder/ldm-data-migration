using System;
using LaDanse.Source.Entities.GameData.Characters;

namespace LaDanse.Source.Entities.GameData.Sync
{
    public partial class TrackedBy
    {
        public string Id { get; set; }
        public int CharacterId { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string CharacterSourceId { get; set; }

        public virtual GuildCharacter Character { get; set; }
        public virtual CharacterSource CharacterSource { get; set; }
    }
}
