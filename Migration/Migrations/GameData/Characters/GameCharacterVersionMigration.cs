using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.GameData.Characters;
using Migration.KeyMappers.GameData.Characters;
using Migration.KeyMappers.GameData.Core;

namespace Migration.Migrations.GameData.Characters
{
    public class GameCharacterVersionMigration : BaseMigration
    {
        private readonly GameCharacterKeyMapper _gameCharacterKeyMapper;
        private readonly GameCharacterVersionKeyMapper _gameCharacterVersionKeyMapper;
        private readonly GameClassKeyMapper _gameClassKeyMapper;
        private readonly GameRaceKeyMapper _gameRaceKeyMapper;
        
        public GameCharacterVersionMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext,
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
        
        public override void Migrate()
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