using System;

namespace Migration.KeyMappers.Forums
{
    public class UnreadPostKeyMapper : GenericKeyMapper<string, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}