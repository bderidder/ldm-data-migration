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
        private readonly TelemetryMigrations _telemetryMigrations;
        
        public AllTargetMigrations(
            AllCharacterClaimsMigration allCharacterClaimsMigration,
            IdentityMigrations identityMigrations,
            TelemetryMigrations telemetryMigrations, 
            AllCommentsMigration allCommentsMigration)
        {
            _allCharacterClaimsMigration = allCharacterClaimsMigration;
            _identityMigrations = identityMigrations;
            _telemetryMigrations = telemetryMigrations;
            _allCommentsMigration = allCommentsMigration;
        }
        
        public void Migrate()
        {
            _identityMigrations.Migrate();
            _allCharacterClaimsMigration.Migrate();
            _allCommentsMigration.Migrate();
            _telemetryMigrations.Migrate();
        }
    }
}