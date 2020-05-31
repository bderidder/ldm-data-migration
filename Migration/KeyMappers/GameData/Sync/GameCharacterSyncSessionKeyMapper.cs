using System;

namespace LaDanse.Migration.KeyMappers.GameData.Sync
{
    public class GameCharacterSyncSessionKeyMapper : GenericKeyMapper<string, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}