using System;

namespace Migration.KeyMappers.GameData.Sync
{
    public class GameCharacterSourceKeyMapper : GenericKeyMapper<Guid, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}