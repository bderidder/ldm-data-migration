using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.GameData.Sync.Guild;
using Migration.KeyMappers.GameData.Characters;
using Migration.KeyMappers.GameData.Core;

namespace Migration.Migrations.GameData.Sync.Guild
{
    public class GameGuildSyncMigration : BaseMigration, IMigration
    {
        private readonly GameGuildSyncKeyMapper _gameGuildSyncKeyMapper;
        private readonly GameGuildKeyMapper _gameGuildKeyMapper;
        
        public GameGuildSyncMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext, 
            GameGuildSyncKeyMapper gameGuildSyncKeyMapper, 
            GameGuildKeyMapper gameGuildKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _gameGuildSyncKeyMapper = gameGuildSyncKeyMapper;
            _gameGuildKeyMapper = gameGuildKeyMapper;
        }
        
        public void Migrate()
        {
            var guildSyncs = SourceDbContext.GuildSyncs.ToList();

            foreach (var guildSync in guildSyncs)
            {
                var newEntity = new GameGuildSync()
                {
                    Id = _gameGuildSyncKeyMapper.MapKey(guildSync.Id), 
                    GameGuildId = _gameGuildKeyMapper.MapKey(guildSync.GuildId)
                };

                TargetDbContext.GameGuildSyncs.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}