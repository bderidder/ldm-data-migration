using System;

namespace LaDanse.Migration.KeyMappers.GameData.Core
{
    public class GameRealmKeyMapper : GenericKeyMapper<string, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}