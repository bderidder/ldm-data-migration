namespace Migration.Migrations.Telemetry
{
    public class TelemetryMigrations : IMigration
    {
        private readonly FeedbackMigration _feedbackMigration;
        
        public TelemetryMigrations(FeedbackMigration feedbackMigration)
        {
            _feedbackMigration = feedbackMigration;
        }
        
        public void Migrate()
        {
            _feedbackMigration.Migrate();
        }
    }
}