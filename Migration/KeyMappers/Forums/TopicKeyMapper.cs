using System;

namespace Migration.KeyMappers.Forums
{
    public class TopicKeyMapper : GenericKeyMapper<Guid, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}