using LaDanse.Migration.Migrations.GameData.Sync.Guild;
using LaDanse.Migration.Migrations.GameData.Sync.Profile;

namespace LaDanse.Migration.Migrations.GameData.Sync
{
    public class AllSyncMigrations : IMigration
    {
        private readonly GameGuildSyncMigration _gameGuildSyncMigration;
        private readonly ProfileSyncMigration _profileSyncMigration;
        private readonly TrackedByMigration _trackedByMigration;
        private readonly GameCharacterSyncSessionMigration _gameCharacterSyncSessionMigration;
        
        public AllSyncMigrations(
            GameGuildSyncMigration gameGuildSyncMigration, 
            ProfileSyncMigration profileSyncMigration, 
            TrackedByMigration trackedByMigration, 
            GameCharacterSyncSessionMigration gameCharacterSyncSessionMigration)
        {
            _gameGuildSyncMigration = gameGuildSyncMigration;
            _profileSyncMigration = profileSyncMigration;
            _trackedByMigration = trackedByMigration;
            _gameCharacterSyncSessionMigration = gameCharacterSyncSessionMigration;
        }
        
        public void Migrate()
        {
            _gameGuildSyncMigration.Migrate();
            _profileSyncMigration.Migrate();
            _trackedByMigration.Migrate();
            _gameCharacterSyncSessionMigration.Migrate();
        }
    }
}