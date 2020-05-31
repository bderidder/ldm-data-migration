using System;

namespace Migration.KeyMappers.GameData.Core
{
    public class GameRaceKeyMapper : GenericKeyMapper<string, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}