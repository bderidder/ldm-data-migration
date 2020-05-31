using System;

namespace LaDanse.Migration.KeyMappers.Comments
{
    public class CommentGroupKeyMapper : GenericKeyMapper<string, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}