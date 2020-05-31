using System;

namespace Migration.KeyMappers.GameData.Sync
{
    public class GameCharacterSourceKeyMapper : GenericKeyMapper<string, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}