using System;

namespace Migration.KeyMappers.GameData.Characters
{
    public class InGameGuildKeyMapper : GenericKeyMapper<string, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}