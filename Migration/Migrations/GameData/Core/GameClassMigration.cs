using System.Linq;
using LaDanse.Migration.KeyMappers.GameData.Core;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.GameData.Core;

namespace LaDanse.Migration.Migrations.GameData.Core
{
    public class GameClassMigration : BaseMigration, IMigration
    {
        private readonly GameClassKeyMapper _gameClassKeyMapper;
        
        public GameClassMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext, 
            GameClassKeyMapper gameClassKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _gameClassKeyMapper = gameClassKeyMapper;
        }
        
        public void Migrate()
        {
            var gameClasses = SourceDbContext.GameClasses.ToList();

            foreach (var gameClass in gameClasses)
            {
                var newEntity = new GameClass()
                {
                    Id = _gameClassKeyMapper.MapKey(gameClass.Id), 
                    Name = gameClass.Name, 
                    GameId = gameClass.GameId
                };

                TargetDbContext.GameClasses.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}