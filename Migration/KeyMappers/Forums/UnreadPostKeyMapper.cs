using System;

namespace Migration.KeyMappers.Forums
{
    public class UnreadPostKeyMapper : GenericKeyMapper<Guid, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}