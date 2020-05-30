using System;

namespace LaDanse.Source.Entities.GameData.Core
{
    public partial class GameRace
    {
        public GameRace()
        {
        }

        public Guid Id { get; set; }
        public int GameId { get; set; }
        public Guid FactionId { get; set; }
        public string Name { get; set; }

        public virtual GameFaction Faction { get; set; }
    }
}
