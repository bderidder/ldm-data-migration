using System;

namespace LaDanse.Migration.KeyMappers.Telemetry
{
    public class FeedbackKeyMapper : GenericKeyMapper<int, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}