using System.Linq;
using LaDanse.Migration.KeyMappers.Identity;
using LaDanse.Migration.KeyMappers.Settings;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.Settings;

namespace LaDanse.Migration.Migrations.Settings
{
    public class CalendarExportMigration : BaseMigration, IMigration
    {
        private readonly CalendarExportKeyMapper _calendarExportKeyMapper;
        private readonly UserKeyMapper _userKeyMapper;
        
        public CalendarExportMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext, 
            UserKeyMapper userKeyMapper, 
            CalendarExportKeyMapper calendarExportKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _userKeyMapper = userKeyMapper;
            _calendarExportKeyMapper = calendarExportKeyMapper;
        }
        
        public void Migrate()
        {
            var oldCalendarExports = SourceDbContext.CalendarExports.ToList();

            foreach (var oldCalendarExport in oldCalendarExports)
            {
                var newEntity = new CalendarExport()
                {
                    Id = _calendarExportKeyMapper.MapKey(oldCalendarExport.Id),
                    ExportNew = oldCalendarExport.ExportNew,
                    ExportAbsence = oldCalendarExport.ExportAbsence,
                    Secret = oldCalendarExport.Secret,
                    UserId = _userKeyMapper.MapKey(oldCalendarExport.AccountId)
                };

                TargetDbContext.CalendarExports.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}