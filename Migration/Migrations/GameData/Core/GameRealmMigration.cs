using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.GameData.Core;
using Migration.KeyMappers.GameData.Core;

namespace Migration.Migrations.GameData.Core
{
    public class GameRealmMigration : BaseMigration
    {
        private readonly GameRealmKeyMapper _gameRealmKeyMapper;
        
        public GameRealmMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext,
            GameRealmKeyMapper gameRealmKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _gameRealmKeyMapper = gameRealmKeyMapper;
        }
        
        public override void Migrate()
        {
            var realms = SourceDbContext.Realms.ToList();

            foreach (var realm in realms)
            {
                var newEntity = new GameRealm()
                {
                    Id = _gameRealmKeyMapper.MapKey(realm.Id), 
                    Name = realm.Name, 
                    GameId = realm.GameId
                };

                TargetDbContext.GameRealms.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}