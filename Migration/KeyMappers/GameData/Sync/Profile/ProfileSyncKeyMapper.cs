using System;

namespace Migration.KeyMappers.GameData.Core
{
    public class ProfileSyncKeyMapper : GenericKeyMapper<Guid, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}