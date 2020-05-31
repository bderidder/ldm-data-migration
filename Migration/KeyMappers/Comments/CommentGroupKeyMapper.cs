using System;

namespace Migration.KeyMappers.Comments
{
    public class CommentGroupKeyMapper : GenericKeyMapper<string, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}