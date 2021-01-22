using System.Linq;
using LaDanse.Migration.KeyMappers.GameData.Characters;
using LaDanse.Migration.KeyMappers.GameData.Sync;
using LaDanse.Source;
using LaDanse.Source.MySql;
using LaDanse.Target;
using LaDanse.Target.Entities.GameData.Sync.Guild;
using Target.Shared;

namespace LaDanse.Migration.Migrations.GameData.Sync.Guild
{
    public class GameGuildSyncMigration : BaseMigration, IMigration
    {
        private readonly GameCharacterSourceKeyMapper _gameGuildSyncKeyMapper;
        private readonly GameGuildKeyMapper _gameGuildKeyMapper;
        
        public GameGuildSyncMigration(
            SourceDbContext sourceDbContext, ITargetDbContext targetDbContext, 
            GameCharacterSourceKeyMapper gameGuildSyncKeyMapper, 
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