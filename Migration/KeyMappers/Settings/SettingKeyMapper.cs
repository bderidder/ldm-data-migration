using System;

namespace Migration.KeyMappers.Settings
{
    public class SettingKeyMapper : GenericKeyMapper<int, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}