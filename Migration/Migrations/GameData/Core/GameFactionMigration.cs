using System.Linq;
using LaDanse.Migration.KeyMappers.GameData.Core;
using LaDanse.Source.MySql;
using LaDanse.Target.Entities.GameData.Core;
using Target.Shared;

namespace LaDanse.Migration.Migrations.GameData.Core
{
    public class GameFactionMigration : BaseMigration, IMigration
    {
        private readonly GameFactionKeyMapper _gameFactionKeyMapper;
        
        public GameFactionMigration(
            SourceDbContext sourceDbContext, ITargetDbContext targetDbContext, 
            GameFactionKeyMapper gameFactionKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _gameFactionKeyMapper = gameFactionKeyMapper;
        }
        
        public void Migrate()
        {
            var gameFactions = SourceDbContext.GameFactions.ToList();

            foreach (var gameFaction in gameFactions)
            {
                var newEntity = new GameFaction()
                {
                    Id = _gameFactionKeyMapper.MapKey(gameFaction.Id), 
                    Name = gameFaction.Name, 
                    GameId = gameFaction.GameId
                };

                TargetDbContext.GameFactions.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}