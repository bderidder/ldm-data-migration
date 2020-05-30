using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.GameData.Characters;
using LaDanse.Target.Entities.GameData.Core;
using Migration.KeyMappers.GameData.Characters;
using Migration.KeyMappers.GameData.Core;

namespace Migration.Migrations.GameData.Core
{
    public class GameRaceMigration : BaseMigration
    {
        private readonly GameRaceKeyMapper _gameRaceKeyMapper;
        private readonly GameFactionKeyMapper _gameFactionKeyMapper;
        
        public GameRaceMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext, 
            GameRaceKeyMapper gameRaceKeyMapper, 
            GameFactionKeyMapper gameFactionKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _gameRaceKeyMapper = gameRaceKeyMapper;
            _gameFactionKeyMapper = gameFactionKeyMapper;
        }
        
        public override void Migrate()
        {
            var gameRaces = SourceDbContext.GameRaces.ToList();

            foreach (var gameRace in gameRaces)
            {
                var newEntity = new GameRace()
                {
                    Id = _gameRaceKeyMapper.MapKey(gameRace.Id), 
                    Name = gameRace.Name,
                    GameId = gameRace.GameId,
                    GameFactionId = _gameFactionKeyMapper.MapKey(gameRace.FactionId)
                };

                TargetDbContext.GameRaces.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}