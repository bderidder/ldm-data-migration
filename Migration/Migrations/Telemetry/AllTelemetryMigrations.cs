namespace Migration.Migrations.Telemetry
{
    public class AllTelemetryMigrations : IMigration
    {
        private readonly FeedbackMigration _feedbackMigration;
        
        public AllTelemetryMigrations(FeedbackMigration feedbackMigration)
        {
            _feedbackMigration = feedbackMigration;
        }
        
        public void Migrate()
        {
            _feedbackMigration.Migrate();
        }
    }
}