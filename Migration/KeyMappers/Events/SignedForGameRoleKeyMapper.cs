using System;

namespace Migration.KeyMappers.Events
{
    public class SignedForGameRoleKeyMapper : GenericKeyMapper<int, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}