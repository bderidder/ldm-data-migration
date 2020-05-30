using System;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.GameData.Sync.Guild
{
    public partial class GameGuildSync : GameCharacterSource
    {
        public Guid GameGuildId { get; set; }
        public virtual Characters.GameGuild GameGuild { get; set; }
    }
}
