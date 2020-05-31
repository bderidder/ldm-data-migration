using Migration.Migrations.CharacterClaims;
using Migration.Migrations.Comments;
using Migration.Migrations.Identity;
using Migration.Migrations.Telemetry;

namespace Migration.Migrations
{
    public class AllTargetMigrations : IMigration
    {
        private readonly AllCharacterClaimsMigration _allCharacterClaimsMigration;
        private readonly AllCommentsMigration _allCommentsMigration;
        private readonly IdentityMigrations _identityMigrations;
        private readonly AllTelemetryMigrations _allTelemetryMigrations;
        
        public AllTargetMigrations(
            AllCharacterClaimsMigration allCharacterClaimsMigration,
            IdentityMigrations identityMigrations,
            AllTelemetryMigrations allTelemetryMigrations, 
            AllCommentsMigration allCommentsMigration)
        {
            _allCharacterClaimsMigration = allCharacterClaimsMigration;
            _identityMigrations = identityMigrations;
            _allTelemetryMigrations = allTelemetryMigrations;
            _allCommentsMigration = allCommentsMigration;
        }
        
        public void Migrate()
        {
            _identityMigrations.Migrate();
            _allCharacterClaimsMigration.Migrate();
            _allCommentsMigration.Migrate();
            _allTelemetryMigrations.Migrate();
        }
    }
}