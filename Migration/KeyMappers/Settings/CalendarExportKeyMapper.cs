using System;

namespace Migration.KeyMappers.Settings
{
    public class CalendarExportKeyMapper : GenericKeyMapper<int, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}