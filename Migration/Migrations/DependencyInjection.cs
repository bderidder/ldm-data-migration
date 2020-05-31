using Microsoft.Extensions.DependencyInjection;
using Migration.Migrations.CharacterClaims;
using Migration.Migrations.Comments;
using Migration.Migrations.Events;
using Migration.Migrations.Forums;
using Migration.Migrations.GameData;
using Migration.Migrations.GameData.Characters;
using Migration.Migrations.GameData.Core;
using Migration.Migrations.GameData.Sync;
using Migration.Migrations.GameData.Sync.Guild;
using Migration.Migrations.GameData.Sync.Profile;
using Migration.Migrations.Identity;
using Migration.Migrations.Telemetry;

namespace Migration.Migrations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMigrations(this IServiceCollection services)
        {
            services.AddScoped<AllTargetMigrations>();
            
            #region CharacterClaims

            services.AddScoped<AllCharacterClaimsMigration>();
            services.AddScoped<GameCharacterClaimMigration>();
            services.AddScoped<GameCharacterClaimVersionMigration>();
            services.AddScoped<PlaysGameRoleMigration>();

            #endregion
            
            #region Comments
            
            services.AddScoped<AllCommentsMigration>();
            services.AddScoped<CommentGroupMigration>();
            services.AddScoped<CommentMigration>();

            #endregion
            
            #region Events

            services.AddScoped<AllEventsMigrations>();
            services.AddScoped<EventMigration>();
            services.AddScoped<SignUpMigration>();
            services.AddScoped<SignedForGameRoleMigration>();
            
            #endregion

            #region Forums
            
            services.AddScoped<AllForumsMigrations>();
            services.AddScoped<ForumMigration>();
            services.AddScoped<TopicMigration>();
            services.AddScoped<PostMigration>();
            services.AddScoped<ForumLastVisitMigration>();
            services.AddScoped<UnreadPostMigration>();

            #endregion
            
            #region GameData
            
            services.AddScoped<AllGameDataMigrations>();
            
            services.AddScoped<AllCoreMigrations>();
            services.AddScoped<GameClassMigration>();
            services.AddScoped<GameFactionMigration>();
            services.AddScoped<GameRaceMigration>();
            services.AddScoped<GameRealmMigration>();
            
            services.AddScoped<AllCharactersMigrations>();
            services.AddScoped<GameCharacterMigration>();
            services.AddScoped<GameCharacterVersionMigration>();
            services.AddScoped<GameGuildMigration>();
            services.AddScoped<InGameGuildMigration>();
            
            services.AddScoped<AllSyncMigrations>();
            services.AddScoped<GameCharacterSyncSessionMigration>();
            services.AddScoped<TrackedByMigration>();
            services.AddScoped<ProfileSyncMigration>();
            services.AddScoped<GameGuildSyncMigration>();
            
            #endregion
            
            #region Identity
            
            services.AddScoped<IdentityMigrations>();
            services.AddScoped<UserMigration>();

            #endregion
            
            #region Queues

            #endregion

            #region Settings

            #endregion

            #region Telemetry
            
            services.AddScoped<AllTelemetryMigrations>();
            services.AddScoped<FeedbackMigration>();
            services.AddScoped<FeatureUseMigration>();
            services.AddScoped<MailSendMigration>();

            #endregion
            
            return services;
        }
    }
}