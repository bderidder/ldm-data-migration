using Migration.Migrations.GameData.Characters;
using Migration.Migrations.GameData.Core;

namespace Migration.Migrations.GameData
{
    public class AllGameDataMigrations : IMigration
    {
        private readonly AllCoreMigrations _allCoreMigrations;
        private readonly AllCharactersMigrations _allCharactersMigrations;
        
        public AllGameDataMigrations(
            AllCoreMigrations allCoreMigrations, 
            AllCharactersMigrations allCharactersMigrations)
        {
            _allCoreMigrations = allCoreMigrations;
            _allCharactersMigrations = allCharactersMigrations;
        }
        
        public void Migrate()
        {
            _allCoreMigrations.Migrate();
            _allCharactersMigrations.Migrate();
        }
    }
}