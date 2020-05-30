using Microsoft.Extensions.DependencyInjection;
using Migration.KeyMappers.CharacterClaims;
using Migration.KeyMappers.GameData.Characters;
using Migration.KeyMappers.GameData.Core;
using Migration.KeyMappers.GameData.Sync;
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

            #endregion

            #region Events

            #endregion

            #region Forums

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