using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.GameData.Characters;
using Migration.KeyMappers.GameData.Characters;
using Migration.KeyMappers.GameData.Core;

namespace Migration.Migrations.GameData.Characters
{
    public class GameGuildMigration : BaseMigration, IMigration
    {
        private readonly GameGuildKeyMapper _gameGuildKeyMapper;
        private readonly GameRealmKeyMapper _gameRealmKeyMapper;
        
        public GameGuildMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext,
            GameGuildKeyMapper gameGuildKeyMapper,
            GameRealmKeyMapper gameRealmKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _gameGuildKeyMapper = gameGuildKeyMapper;
            _gameRealmKeyMapper = gameRealmKeyMapper;
        }
        
        public void Migrate()
        {
            var guilds = SourceDbContext.Guilds.ToList();

            foreach (var guild in guilds)
            {
                var newGuild = new GameGuild()
                {
                    Id = _gameGuildKeyMapper.MapKey(guild.Id), 
                    Name = guild.Name, 
                    GameId = guild.GameId, 
                    GameRealmId = _gameRealmKeyMapper.MapKey(guild.RealmId)
                };

                TargetDbContext.GameGuilds.Add(newGuild);
            }

            TargetDbContext.SaveChanges();
        }
    }
}