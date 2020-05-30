using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.GameData.Characters;
using LaDanse.Target.Entities.GameData.Core;
using Migration.KeyMappers.GameData.Characters;
using Migration.KeyMappers.GameData.Core;

namespace Migration.Migrations.GameData.Characters
{
    public class GameClassMigration : BaseMigration
    {
        private readonly GameClassKeyMapper _gameClassKeyMapper;
        
        public GameClassMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext, 
            GameClassKeyMapper gameClassKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _gameClassKeyMapper = gameClassKeyMapper;
        }
        
        public override void Migrate()
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