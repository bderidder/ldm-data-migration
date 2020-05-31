using System;

namespace LaDanse.Migration.KeyMappers.Events
{
    public class SignUpKeyMapper : GenericKeyMapper<int, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}