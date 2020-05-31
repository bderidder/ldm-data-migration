using LaDanse.Migration.Migrations.CharacterClaims;
using LaDanse.Migration.Migrations.Comments;
using LaDanse.Migration.Migrations.Events;
using LaDanse.Migration.Migrations.Forums;
using LaDanse.Migration.Migrations.GameData;
using LaDanse.Migration.Migrations.GameData.Characters;
using LaDanse.Migration.Migrations.GameData.Core;
using LaDanse.Migration.Migrations.GameData.Sync;
using LaDanse.Migration.Migrations.GameData.Sync.Guild;
using LaDanse.Migration.Migrations.GameData.Sync.Profile;
using LaDanse.Migration.Migrations.Identity;
using LaDanse.Migration.Migrations.Queues;
using LaDanse.Migration.Migrations.Settings;
using LaDanse.Migration.Migrations.Telemetry;
using Microsoft.Extensions.DependencyInjection;

namespace LaDanse.Migration.Migrations
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
            
            services.AddScoped<AllQueuesMigrations>();
            services.AddScoped<ActivityQueueItemMigration>();
            services.AddScoped<NotificationQueueItemMigration>();

            #endregion

            #region Settings
            
            services.AddScoped<AllSettingsMigrations>();
            services.AddScoped<SettingMigration>();
            services.AddScoped<FeatureToggleMigration>();
            services.AddScoped<CalendarExportMigration>();

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