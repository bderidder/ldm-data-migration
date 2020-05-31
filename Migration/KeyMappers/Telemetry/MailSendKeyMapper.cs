using System;

namespace LaDanse.Migration.KeyMappers.Telemetry
{
    public class MailSendKeyMapper : GenericKeyMapper<int, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}