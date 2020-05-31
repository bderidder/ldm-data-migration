using System;

namespace Migration.KeyMappers.Queues
{
    public class ActivityQueueItemKeyMapper : GenericKeyMapper<int, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}