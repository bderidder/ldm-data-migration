using System;

namespace LaDanse.Migration.KeyMappers.Comments
{
    public class CommentKeyMapper : GenericKeyMapper<string, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}