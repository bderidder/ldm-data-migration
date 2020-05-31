using System;

namespace Migration.KeyMappers.GameData.Core
{
    public class GameClassKeyMapper : GenericKeyMapper<string, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}