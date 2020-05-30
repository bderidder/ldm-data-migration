using System;
using LaDanse.Source.Entities.CharacterClaims;

namespace LaDanse.Source.Entities.CharacterClaims
{
    public partial class CharacterClaimVersion
    {
        public int Id { get; set; }

        public string Comment { get; set; }
        public bool Raider { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }

        public int CharacterClaimId { get; set; }
        public virtual CharacterClaim CharacterClaim { get; set; }
    }
}
