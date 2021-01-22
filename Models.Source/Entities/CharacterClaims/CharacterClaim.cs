using System;
using LaDanse.Source.Entities.GameData.Characters;
using LaDanse.Source.Entities.Identity;

namespace LaDanse.Source.Entities.CharacterClaims
{
    public partial class CharacterClaim
    {
        public int Id { get; set; }

        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }

        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        public int CharacterId { get; set; }
        public virtual GuildCharacter Character { get; set; }
    }
}
