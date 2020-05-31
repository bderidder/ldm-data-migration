using System;

namespace LaDanse.Migration.KeyMappers.Telemetry
{
    public class FeatureUseKeyMapper : GenericKeyMapper<int, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}