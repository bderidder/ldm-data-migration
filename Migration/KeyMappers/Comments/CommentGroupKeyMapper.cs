using System;

namespace Migration.KeyMappers.Comments
{
    public class CommentGroupKeyMapper : GenericKeyMapper<Guid, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}