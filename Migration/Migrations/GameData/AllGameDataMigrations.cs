using Migration.Migrations.GameData.Characters;
using Migration.Migrations.GameData.Core;
using Migration.Migrations.GameData.Sync;

namespace Migration.Migrations.GameData
{
    public class AllGameDataMigrations : IMigration
    {
        private readonly AllCoreMigrations _allCoreMigrations;
        private readonly AllCharactersMigrations _allCharactersMigrations;
        private readonly AllSyncMigrations _allSyncMigrations;
        
        public AllGameDataMigrations(
            AllCoreMigrations allCoreMigrations, 
            AllCharactersMigrations allCharactersMigrations, 
            AllSyncMigrations allSyncMigrations)
        {
            _allCoreMigrations = allCoreMigrations;
            _allCharactersMigrations = allCharactersMigrations;
            _allSyncMigrations = allSyncMigrations;
        }
        
        public void Migrate()
        {
            _allCoreMigrations.Migrate();
            _allCharactersMigrations.Migrate();
            _allSyncMigrations.Migrate();
        }
    }
}