using System;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.GameData.Core
{
    public partial class GameClass : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; }
    }
}
