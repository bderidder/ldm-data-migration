using System;

namespace Migration.KeyMappers.GameData.Characters
{
    public class GameGuildKeyMapper : GenericKeyMapper<Guid, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}