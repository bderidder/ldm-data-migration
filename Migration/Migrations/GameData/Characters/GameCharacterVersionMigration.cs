using System.Linq;
using LaDanse.Migration.KeyMappers.GameData.Characters;
using LaDanse.Migration.KeyMappers.GameData.Core;
using LaDanse.Source;
using LaDanse.Source.MySql;
using LaDanse.Target;
using LaDanse.Target.Entities.GameData.Characters;
using Target.Shared;

namespace LaDanse.Migration.Migrations.GameData.Characters
{
    public class GameCharacterVersionMigration : BaseMigration, IMigration
    {
        private readonly GameCharacterKeyMapper _gameCharacterKeyMapper;
        private readonly GameCharacterVersionKeyMapper _gameCharacterVersionKeyMapper;
        private readonly GameClassKeyMapper _gameClassKeyMapper;
        private readonly GameRaceKeyMapper _gameRaceKeyMapper;
        
        public GameCharacterVersionMigration(
            SourceDbContext sourceDbContext, ITargetDbContext targetDbContext,
            GameCharacterKeyMapper gameCharacterKeyMapper,
            GameCharacterVersionKeyMapper gameCharacterVersionKeyMapper,
            GameClassKeyMapper gameClassKeyMapper,
            GameRaceKeyMapper gameRaceKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _gameCharacterKeyMapper = gameCharacterKeyMapper;
            _gameCharacterVersionKeyMapper = gameCharacterVersionKeyMapper;
            _gameClassKeyMapper = gameClassKeyMapper;
            _gameRaceKeyMapper = gameRaceKeyMapper;
        }
        
        public void Migrate()
        {
            var guildCharacterVersions = SourceDbContext.GuildCharacterVersions.ToList();

            foreach (var guildCharacterVersion in guildCharacterVersions)
            {
                var newEntity = new GameCharacterVersion()
                {
                    Id = _gameCharacterVersionKeyMapper.MapKey(guildCharacterVersion.Id), 
                    FromTime = guildCharacterVersion.FromTime, 
                    EndTime = guildCharacterVersion.EndTime, 
                    Level = guildCharacterVersion.Level,
                    GameCharacterId = _gameCharacterKeyMapper.MapKey(guildCharacterVersion.CharacterId),
                    GameRaceId = _gameRaceKeyMapper.MapKey(guildCharacterVersion.GameRaceId),
                    GameClassId = _gameClassKeyMapper.MapKey(guildCharacterVersion.GameClassId)
                };

                TargetDbContext.GameCharacterVersions.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}