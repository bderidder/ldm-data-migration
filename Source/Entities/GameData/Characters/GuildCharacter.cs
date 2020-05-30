using System;
using LaDanse.Source.Entities.GameData.Core;

namespace LaDanse.Source.Entities.GameData.Characters
{
    public partial class GuildCharacter
    {
        public GuildCharacter()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Guid RealmId { get; set; }

        public virtual GameRealm Realm { get; set; }
    }
}
