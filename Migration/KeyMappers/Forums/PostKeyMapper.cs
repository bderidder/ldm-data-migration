using System;

namespace Migration.KeyMappers.Forums
{
    public class PostKeyMapper : GenericKeyMapper<Guid, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}