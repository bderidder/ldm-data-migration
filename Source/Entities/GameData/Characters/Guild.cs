using System;
using LaDanse.Source.Entities.GameData.Core;

namespace LaDanse.Source.Entities.GameData.Characters
{
    public partial class Guild
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public int GameId { get; set; }

        public Guid RealmId { get; set; }
        public virtual GameRealm Realm { get; set; }
    }
}
