using Migration.Migrations.CharacterClaims;
using Migration.Migrations.Comments;
using Migration.Migrations.Events;
using Migration.Migrations.Forums;
using Migration.Migrations.GameData;
using Migration.Migrations.Identity;
using Migration.Migrations.Queues;
using Migration.Migrations.Settings;
using Migration.Migrations.Telemetry;

namespace Migration.Migrations
{
    public class AllTargetMigrations : IMigration
    {
        private readonly AllCharacterClaimsMigration _allCharacterClaimsMigration;
        private readonly AllCommentsMigration _allCommentsMigration;
        private readonly AllEventsMigrations _allEventsMigrations;
        private readonly AllForumsMigrations _allForumsMigrations;
        private readonly IdentityMigrations _identityMigrations;
        private readonly AllQueuesMigrations _allQueuesMigrations;
        private readonly AllTelemetryMigrations _allTelemetryMigrations;
        private readonly AllSettingsMigrations _allSettingsMigrations;
        private readonly AllGameDataMigrations _allGameDataMigrations;
        
        public AllTargetMigrations(
            AllCharacterClaimsMigration allCharacterClaimsMigration,
            IdentityMigrations identityMigrations,
            AllTelemetryMigrations allTelemetryMigrations, 
            AllCommentsMigration allCommentsMigration, 
            AllEventsMigrations allEventsMigrations, 
            AllForumsMigrations allForumsMigrations, 
            AllQueuesMigrations allQueuesMigrations, AllSettingsMigrations allSettingsMigrations, 
            AllGameDataMigrations allGameDataMigrations)
        {
            _allCharacterClaimsMigration = allCharacterClaimsMigration;
            _identityMigrations = identityMigrations;
            _allTelemetryMigrations = allTelemetryMigrations;
            _allCommentsMigration = allCommentsMigration;
            _allEventsMigrations = allEventsMigrations;
            _allForumsMigrations = allForumsMigrations;
            _allQueuesMigrations = allQueuesMigrations;
            _allSettingsMigrations = allSettingsMigrations;
            _allGameDataMigrations = allGameDataMigrations;
        }
        
        public void Migrate()
        {
            // users must be migrated first
            _identityMigrations.Migrate();
            _allGameDataMigrations.Migrate();
            // game data must have been migrated at this point
            _allCharacterClaimsMigration.Migrate();
            _allCommentsMigration.Migrate();
            // comments must have been migrated at this point
            _allEventsMigrations.Migrate();
            _allForumsMigrations.Migrate();
            _allQueuesMigrations.Migrate();
            _allSettingsMigrations.Migrate();
            _allTelemetryMigrations.Migrate();
            
        }
    }
}