using System;

namespace LaDanse.Source.Entities.GameData.Core
{
    public partial class GameRealm
    {
        public GameRealm()
        {
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int GameId { get; set; }
    }
}
