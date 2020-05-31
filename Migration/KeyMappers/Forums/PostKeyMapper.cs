using System;

namespace Migration.KeyMappers.Forums
{
    public class PostKeyMapper : GenericKeyMapper<string, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}