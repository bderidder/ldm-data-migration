using System;

namespace Migration.KeyMappers.GameData.Sync.Guild
{
    public class GameGuildSyncKeyMapper : GenericKeyMapper<Guid, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}