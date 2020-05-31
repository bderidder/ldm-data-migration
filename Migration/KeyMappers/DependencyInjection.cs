using Microsoft.Extensions.DependencyInjection;
using Migration.KeyMappers.CharacterClaims;
using Migration.KeyMappers.Comments;
using Migration.KeyMappers.Events;
using Migration.KeyMappers.Forums;
using Migration.KeyMappers.GameData.Characters;
using Migration.KeyMappers.GameData.Core;
using Migration.KeyMappers.GameData.Sync;
using Migration.KeyMappers.GameData.Sync.Guild;
using Migration.KeyMappers.GameData.Sync.Profile;
using Migration.KeyMappers.Identity;
using Migration.KeyMappers.Telemetry;

namespace Migration.KeyMappers
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
            services.AddScoped<ProfileSyncKeyMapper>();
            services.AddScoped<GameGuildSyncKeyMapper>();

            #endregion

            #region Identity
            
            services.AddScoped<UserKeyMapper>();

            #endregion

            #region Queues

            #endregion

            #region Settings

            #endregion

            #region Shared

            #endregion

            #region Telemetry
            
            services.AddScoped<FeedbackKeyMapper>();

            #endregion
            
            return services;
        }
    }
}