using System;

namespace Migration.KeyMappers.Forums
{
    public class ForumKeyMapper : GenericKeyMapper<Guid, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}