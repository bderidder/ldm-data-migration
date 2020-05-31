using System;

namespace LaDanse.Migration.KeyMappers.GameData.Core
{
    public class GameFactionKeyMapper : GenericKeyMapper<string, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}