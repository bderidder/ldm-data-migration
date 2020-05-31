using LaDanse.Migration.Migrations.GameData.Characters;
using LaDanse.Migration.Migrations.GameData.Core;
using LaDanse.Migration.Migrations.GameData.Sync;

namespace LaDanse.Migration.Migrations.GameData
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