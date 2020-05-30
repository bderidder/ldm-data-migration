using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.GameData.Characters;
using LaDanse.Target.Entities.GameData.Core;
using Migration.KeyMappers.GameData.Characters;
using Migration.KeyMappers.GameData.Core;

namespace Migration.Migrations.GameData.Core
{
    public class GameFactionMigration : BaseMigration
    {
        private readonly GameFactionKeyMapper _gameFactionKeyMapper;
        
        public GameFactionMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext, 
            GameFactionKeyMapper gameFactionKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _gameFactionKeyMapper = gameFactionKeyMapper;
        }
        
        public override void Migrate()
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