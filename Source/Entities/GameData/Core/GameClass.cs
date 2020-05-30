using System;

namespace LaDanse.Source.Entities.GameData.Core
{
    public partial class GameClass
    {
        public GameClass()
        {
        }

        public Guid Id { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; }
    }
}
