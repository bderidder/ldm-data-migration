using System;

namespace Migration.KeyMappers.GameData.Sync
{
    public class TrackedByKeyMapper : GenericKeyMapper<string, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}