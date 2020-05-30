using System;
using LaDanse.Source.Entities.GameData.Characters;

namespace LaDanse.Source.Entities.GameData.Sync
{
    public partial class TrackedBy
    {
        public Guid Id { get; set; }
        public int CharacterId { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Guid CharacterSourceId { get; set; }

        public virtual GuildCharacter Character { get; set; }
        public virtual CharacterSource CharacterSource { get; set; }
    }
}
