using System;
using LaDanse.Source.Entities.CharacterClaims;
using LaDanse.Source.Entities.GameData;

namespace LaDanse.Source.Entities.CharacterClaims
{
    public partial class PlaysRole
    {
        public int Id { get; set; }

        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Role Role { get; set; }
        
        public int CharacterClaimId { get; set; }
        public virtual CharacterClaim CharacterClaim { get; set; }
    }
}
