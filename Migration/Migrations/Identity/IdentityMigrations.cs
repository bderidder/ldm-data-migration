namespace LaDanse.Migration.Migrations.Identity
{
    public class IdentityMigrations : IMigration
    {
        private readonly UserMigration _userMigration;
        
        public IdentityMigrations(UserMigration userMigration)
        {
            _userMigration = userMigration;
        }
        
        public void Migrate()
        {
            _userMigration.Migrate();
        }
    }
}