using System;

namespace LaDanse.Migration.KeyMappers.Identity
{
    public class UserKeyMapper : GenericKeyMapper<int, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}