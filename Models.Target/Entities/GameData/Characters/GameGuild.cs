using System;
using LaDanse.Target.Entities.GameData.Core;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.GameData.Characters
{
    public partial class GameGuild : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public string GameSlug { get; set; }
        public int GameId { get; set; }

        public Guid GameRealmId { get; set; }
        public virtual GameRealm GameRealm { get; set; }
    }
}
