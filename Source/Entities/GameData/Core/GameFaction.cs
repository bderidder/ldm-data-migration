using System;

namespace LaDanse.Source.Entities.GameData.Core
{
    public partial class GameFaction
    {
        public GameFaction()
        {
        }

        public Guid Id { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; }
    }
}
