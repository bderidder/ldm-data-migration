using System;

namespace LaDanse.Migration.KeyMappers.Events
{
    public class EventKeyMapper : GenericKeyMapper<int, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}