using System;

namespace LaDanse.Source.Entities.GameData.Characters
{
    public partial class InGuild
    {
        public string Id { get; set; }
        public string GuildId { get; set; }
        public int CharacterId { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual GuildCharacter Character { get; set; }
        public virtual Guild Guild { get; set; }
    }
}
