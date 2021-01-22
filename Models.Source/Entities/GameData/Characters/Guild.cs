using System;
using LaDanse.Source.Entities.GameData.Core;

namespace LaDanse.Source.Entities.GameData.Characters
{
    public partial class Guild
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        public int GameId { get; set; }

        public string RealmId { get; set; }
        public virtual GameRealm Realm { get; set; }
    }
}
