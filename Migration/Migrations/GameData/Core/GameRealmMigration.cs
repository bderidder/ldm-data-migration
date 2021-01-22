using System.Linq;
using LaDanse.Migration.KeyMappers.GameData.Core;
using LaDanse.Source;
using LaDanse.Source.MySql;
using LaDanse.Target;
using LaDanse.Target.Entities.GameData.Core;
using Target.Shared;

namespace LaDanse.Migration.Migrations.GameData.Core
{
    public class GameRealmMigration : BaseMigration, IMigration
    {
        private readonly GameRealmKeyMapper _gameRealmKeyMapper;
        
        public GameRealmMigration(
            SourceDbContext sourceDbContext, ITargetDbContext targetDbContext,
            GameRealmKeyMapper gameRealmKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _gameRealmKeyMapper = gameRealmKeyMapper;
        }
        
        public void Migrate()
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