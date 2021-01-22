using System;
using LaDanse.Target.Entities.GameData;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.CharacterClaims
{
    public partial class PlaysGameRole : IBaseEntity<Guid>, ITimeVersionedEntity
    {
        public Guid Id { get; set; }

        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }
        
        public GameRole GameRole { get; set; }
        
        public Guid GameCharacterClaimId { get; set; }
        public virtual GameCharacterClaim GameCharacterClaim { get; set; }
    }
}
