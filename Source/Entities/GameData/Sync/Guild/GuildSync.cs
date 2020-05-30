using System;

namespace LaDanse.Source.Entities.GameData.Sync.Guild
{
    public partial class GuildSync
    {
        public Guid Id { get; set; }

        public Guid GuildId { get; set; }
        public virtual Characters.Guild Guild { get; set; }
    }
}
