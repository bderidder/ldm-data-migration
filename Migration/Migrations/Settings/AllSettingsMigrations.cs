namespace Migration.Migrations.Settings
{
    public class AllSettingsMigrations : IMigration
    {
        private readonly SettingMigration _settingMigration;
        private readonly FeatureToggleMigration _featureToggleMigration;
        private readonly CalendarExportMigration _calendarExportMigration;
        
        public AllSettingsMigrations(
            SettingMigration settingMigration, 
            FeatureToggleMigration featureToggleMigration, 
            CalendarExportMigration calendarExportMigration)
        {
            _settingMigration = settingMigration;
            _featureToggleMigration = featureToggleMigration;
            _calendarExportMigration = calendarExportMigration;
        }
        
        public void Migrate()
        {
            _settingMigration.Migrate();
            _featureToggleMigration.Migrate();
            _calendarExportMigration.Migrate();
        }
    }
}