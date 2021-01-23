using System;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.GameData.Core
{
    public partial class GameRealm : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string GameSlug { get; set; }
        public int GameId { get; set; }
    }
}
