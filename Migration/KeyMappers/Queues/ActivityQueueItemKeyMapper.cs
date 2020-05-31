using System;

namespace LaDanse.Migration.KeyMappers.Queues
{
    public class ActivityQueueItemKeyMapper : GenericKeyMapper<int, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}