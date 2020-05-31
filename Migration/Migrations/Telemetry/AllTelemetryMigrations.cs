namespace LaDanse.Migration.Migrations.Telemetry
{
    public class AllTelemetryMigrations : IMigration
    {
        private readonly FeedbackMigration _feedbackMigration;
        private readonly FeatureUseMigration _featureUseMigration;
        private readonly MailSendMigration _mailSendMigration;
        
        public AllTelemetryMigrations(
            FeedbackMigration feedbackMigration, 
            FeatureUseMigration featureUseMigration, 
            MailSendMigration mailSendMigration)
        {
            _feedbackMigration = feedbackMigration;
            _featureUseMigration = featureUseMigration;
            _mailSendMigration = mailSendMigration;
        }
        
        public void Migrate()
        {
            _feedbackMigration.Migrate();
            _mailSendMigration.Migrate();
            _featureUseMigration.Migrate();
        }
    }
}