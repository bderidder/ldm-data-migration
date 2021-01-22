using System;
using LaDanse.Target.Entities.GameData.Characters;

namespace LaDanse.Target.Entities.GameData.Sync.Guild
{
    public partial class GameGuildSync : GameCharacterSource
    {
        public Guid GameGuildId { get; set; }
        public virtual GameGuild GameGuild { get; set; }
    }
}
