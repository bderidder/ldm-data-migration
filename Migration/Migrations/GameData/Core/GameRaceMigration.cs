using System.Linq;
using LaDanse.Migration.KeyMappers.GameData.Core;
using LaDanse.Source;
using LaDanse.Source.MySql;
using LaDanse.Target;
using LaDanse.Target.Entities.GameData.Core;
using Target.Shared;

namespace LaDanse.Migration.Migrations.GameData.Core
{
    public class GameRaceMigration : BaseMigration, IMigration
    {
        private readonly GameRaceKeyMapper _gameRaceKeyMapper;
        private readonly GameFactionKeyMapper _gameFactionKeyMapper;
        
        public GameRaceMigration(
            SourceDbContext sourceDbContext, ITargetDbContext targetDbContext, 
            GameRaceKeyMapper gameRaceKeyMapper, 
            GameFactionKeyMapper gameFactionKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _gameRaceKeyMapper = gameRaceKeyMapper;
            _gameFactionKeyMapper = gameFactionKeyMapper;
        }
        
        public void Migrate()
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