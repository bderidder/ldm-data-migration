using System;

namespace Migration.KeyMappers.GameData.Sync
{
    public class TrackedByKeyMapper : GenericKeyMapper<Guid, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}