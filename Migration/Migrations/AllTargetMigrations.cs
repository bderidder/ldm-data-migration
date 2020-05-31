using Migration.Migrations.CharacterClaims;
using Migration.Migrations.Comments;
using Migration.Migrations.Events;
using Migration.Migrations.Forums;
using Migration.Migrations.Identity;
using Migration.Migrations.Queues;
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
        
        public AllTargetMigrations(
            AllCharacterClaimsMigration allCharacterClaimsMigration,
            IdentityMigrations identityMigrations,
            AllTelemetryMigrations allTelemetryMigrations, 
            AllCommentsMigration allCommentsMigration, 
            AllEventsMigrations allEventsMigrations, 
            AllForumsMigrations allForumsMigrations, 
            AllQueuesMigrations allQueuesMigrations)
        {
            _allCharacterClaimsMigration = allCharacterClaimsMigration;
            _identityMigrations = identityMigrations;
            _allTelemetryMigrations = allTelemetryMigrations;
            _allCommentsMigration = allCommentsMigration;
            _allEventsMigrations = allEventsMigrations;
            _allForumsMigrations = allForumsMigrations;
            _allQueuesMigrations = allQueuesMigrations;
        }
        
        public void Migrate()
        {
            _identityMigrations.Migrate();
            _allCharacterClaimsMigration.Migrate();
            _allCommentsMigration.Migrate();
            _allForumsMigrations.Migrate();
            _allEventsMigrations.Migrate();
            _allQueuesMigrations.Migrate();
            _allTelemetryMigrations.Migrate();
        }
    }
}