using System;

namespace LaDanse.Migration.KeyMappers.Queues
{
    public class NotificationQueueItemKeyMapper : GenericKeyMapper<int, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}