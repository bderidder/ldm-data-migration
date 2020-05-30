using System;

namespace Migration.KeyMappers.GameData.Sync
{
    public class GameCharacterSyncSessionKeyMapper : GenericKeyMapper<Guid, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}