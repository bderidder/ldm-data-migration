using System;

namespace Migration.KeyMappers.GameData.Core
{
    public class GameRealmKeyMapper : GenericKeyMapper<Guid, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}