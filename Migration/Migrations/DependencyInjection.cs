using Microsoft.Extensions.DependencyInjection;
using Migration.Migrations.CharacterClaims;
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

            services.AddScoped<GameCharacterClaimMigration>();
            services.AddScoped<GameCharacterClaimVersionMigration>();
            services.AddScoped<PlaysGameRoleMigration>();
            services.AddScoped<AllCharacterClaimsMigration>();
            
            #endregion
            
            #region Comments

            #endregion
            
            #region Events

            #endregion

            #region Forums

            #endregion
            
            #region GameData

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
            
            services.AddScoped<TelemetryMigrations>();
            
            services.AddScoped<FeedbackMigration>();

            #endregion
            
            return services;
        }
    }
}