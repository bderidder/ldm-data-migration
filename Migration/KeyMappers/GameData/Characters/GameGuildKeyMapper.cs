using System;

namespace Migration.KeyMappers.GameData.Characters
{
    public class GameGuildKeyMapper : GenericKeyMapper<string, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}