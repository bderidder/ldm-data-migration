using System;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.GameData.Sync
{
    public partial class GameCharacterSource : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
