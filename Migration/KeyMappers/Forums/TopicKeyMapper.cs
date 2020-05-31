using System;

namespace LaDanse.Migration.KeyMappers.Forums
{
    public class TopicKeyMapper : GenericKeyMapper<string, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}