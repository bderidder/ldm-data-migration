using LaDanse.Migration.KeyMappers.CharacterClaims;
using LaDanse.Migration.KeyMappers.Comments;
using LaDanse.Migration.KeyMappers.Events;
using LaDanse.Migration.KeyMappers.Forums;
using LaDanse.Migration.KeyMappers.GameData.Characters;
using LaDanse.Migration.KeyMappers.GameData.Core;
using LaDanse.Migration.KeyMappers.GameData.Sync;
using LaDanse.Migration.KeyMappers.Identity;
using LaDanse.Migration.KeyMappers.Queues;
using LaDanse.Migration.KeyMappers.Settings;
using LaDanse.Migration.KeyMappers.Telemetry;
using Microsoft.Extensions.DependencyInjection;

namespace LaDanse.Migration.KeyMappers
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddKeyMappers(this IServiceCollection services)
        {
            #region CharacterClaims
            
            services.AddScoped<GameCharacterClaimKeyMapper>();
            services.AddScoped<GameCharacterClaimVersionKeyMapper>();
            services.AddScoped<PlaysGameRoleKeyMapper>();

            #endregion

            #region Comments
            
            services.AddScoped<CommentGroupKeyMapper>();
            services.AddScoped<CommentKeyMapper>();

            #endregion

            #region Events
            
            services.AddScoped<EventKeyMapper>();
            services.AddScoped<SignUpKeyMapper>();
            services.AddScoped<SignedForGameRoleKeyMapper>();

            #endregion

            #region Forums
            
            services.AddScoped<ForumKeyMapper>();
            services.AddScoped<ForumLastVisitKeyMapper>();
            services.AddScoped<PostKeyMapper>();
            services.AddScoped<TopicKeyMapper>();
            services.AddScoped<UnreadPostKeyMapper>();

            #endregion

            #region GameData
            
            services.AddScoped<GameRealmKeyMapper>();
            services.AddScoped<GameRaceKeyMapper>();
            services.AddScoped<GameFactionKeyMapper>();
            services.AddScoped<GameClassKeyMapper>();
            
            services.AddScoped<GameGuildKeyMapper>();
            services.AddScoped<InGameGuildKeyMapper>();
            services.AddScoped<GameCharacterKeyMapper>();
            services.AddScoped<GameCharacterVersionKeyMapper>();
            
            services.AddScoped<GameCharacterSourceKeyMapper>();
            services.AddScoped<GameCharacterSyncSessionKeyMapper>();
            services.AddScoped<TrackedByKeyMapper>();

            #endregion

            #region Identity
            
            services.AddScoped<UserKeyMapper>();

            #endregion

            #region Queues
            
            services.AddScoped<ActivityQueueItemKeyMapper>();
            services.AddScoped<NotificationQueueItemKeyMapper>();

            #endregion

            #region Settings
            
            services.AddScoped<SettingKeyMapper>();
            services.AddScoped<FeatureToggleKeyMapper>();
            services.AddScoped<CalendarExportKeyMapper>();

            #endregion

            #region Shared

            #endregion

            #region Telemetry
            
            services.AddScoped<FeedbackKeyMapper>();
            services.AddScoped<MailSendKeyMapper>();
            services.AddScoped<FeatureUseKeyMapper>();

            #endregion
            
            return services;
        }
    }
}