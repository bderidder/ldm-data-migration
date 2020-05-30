using System;

namespace Migration.KeyMappers.GameData.Characters
{
    public class InGameGuildKeyMapper : GenericKeyMapper<Guid, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}