using System;

namespace LaDanse.Source.Entities.CharacterClaims
{
    public partial class StringPlaysRole
    {
        public int Id { get; set; }

        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Role { get; set; }

        public int CharacterClaimId { get; set; }
        public virtual CharacterClaim CharacterClaim { get; set; }
    }
}
