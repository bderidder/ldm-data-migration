using System;

namespace Migration.KeyMappers.Settings
{
    public class FeatureToggleKeyMapper : GenericKeyMapper<int, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}