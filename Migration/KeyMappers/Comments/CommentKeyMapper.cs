using System;

namespace Migration.KeyMappers.Comments
{
    public class CommentKeyMapper : GenericKeyMapper<Guid, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}