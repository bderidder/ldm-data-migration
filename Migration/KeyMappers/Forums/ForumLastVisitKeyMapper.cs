using System;

namespace Migration.KeyMappers.Forums
{
    public class ForumLastVisitKeyMapper : GenericKeyMapper<Guid, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}