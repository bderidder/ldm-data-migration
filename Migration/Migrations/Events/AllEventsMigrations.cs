namespace Migration.Migrations.Events
{
    public class AllEventsMigrations : IMigration
    {
        private readonly EventMigration _eventMigration;
        private readonly SignUpMigration _signUpMigration;
        private readonly SignedForGameRoleMigration _signedForGameRoleMigration;
        
        public AllEventsMigrations(
            EventMigration eventMigration, 
            SignUpMigration signUpMigration, 
            SignedForGameRoleMigration signedForGameRoleMigration)
        {
            _eventMigration = eventMigration;
            _signUpMigration = signUpMigration;
            _signedForGameRoleMigration = signedForGameRoleMigration;
        }
        
        public void Migrate()
        {
            _eventMigration.Migrate();
            _signUpMigration.Migrate();
            _signedForGameRoleMigration.Migrate();
        }
    }
}