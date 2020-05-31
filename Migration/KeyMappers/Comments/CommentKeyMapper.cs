using System;

namespace Migration.KeyMappers.Comments
{
    public class CommentKeyMapper : GenericKeyMapper<string, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}