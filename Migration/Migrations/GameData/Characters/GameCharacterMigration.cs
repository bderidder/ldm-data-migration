using System.Linq;
using LaDanse.Migration.KeyMappers.GameData.Characters;
using LaDanse.Migration.KeyMappers.GameData.Core;
using LaDanse.Source.MySql;
using LaDanse.Target.Entities.GameData.Characters;
using Target.Shared;

namespace LaDanse.Migration.Migrations.GameData.Characters
{
    public class GameCharacterMigration : BaseMigration, IMigration
    {
        private readonly GameCharacterKeyMapper _gameCharacterKeyMapper;
        private readonly GameRealmKeyMapper _gameRealmKeyMapper;
        
        public GameCharacterMigration(
            SourceDbContext sourceDbContext, ITargetDbContext targetDbContext,
            GameCharacterKeyMapper gameCharacterKeyMapper,
            GameRealmKeyMapper gameRealmKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _gameCharacterKeyMapper = gameCharacterKeyMapper;
            _gameRealmKeyMapper = gameRealmKeyMapper;
        }
        
        public void Migrate()
        {
            var guildCharacters = SourceDbContext.GuildCharacters.ToList();

            foreach (var guildCharacter in guildCharacters)
            {
                var newEntity = new GameCharacter()
                {
                    Id = _gameCharacterKeyMapper.MapKey(guildCharacter.Id), 
                    Name = guildCharacter.Name, 
                    FromTime = guildCharacter.FromTime, 
                    EndTime = guildCharacter.EndTime, 
                    GameRealmId = _gameRealmKeyMapper.MapKey(guildCharacter.RealmId)
                };

                TargetDbContext.GameCharacters.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}