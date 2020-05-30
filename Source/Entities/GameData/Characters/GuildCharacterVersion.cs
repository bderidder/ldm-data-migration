using System;
using LaDanse.Source.Entities.GameData.Core;

namespace LaDanse.Source.Entities.GameData.Characters
{
    public partial class GuildCharacterVersion
    {
        public int Id { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }
        public short Level { get; set; }
        public int CharacterId { get; set; }
        public Guid GameClassId { get; set; }
        public Guid GameRaceId { get; set; }

        public virtual GuildCharacter Character { get; set; }
        public virtual GameClass GameClass { get; set; }
        public virtual GameRace GameRace { get; set; }
    }
}
