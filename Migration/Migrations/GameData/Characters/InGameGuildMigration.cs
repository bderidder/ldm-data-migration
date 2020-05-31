using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.GameData.Characters;
using Migration.KeyMappers.GameData.Characters;

namespace Migration.Migrations.GameData.Characters
{
    public class InGameGuildMigration : BaseMigration, IMigration
    {
        private readonly InGameGuildKeyMapper _inGameGuildKeyMapper;
        private readonly GameCharacterKeyMapper _gameCharacterKeyMapper;
        private readonly GameGuildKeyMapper _gameGuildKeyMapper;
        
        public InGameGuildMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext, 
            InGameGuildKeyMapper inGameGuildKeyMapper, 
            GameCharacterKeyMapper gameCharacterKeyMapper, 
            GameGuildKeyMapper gameGuildKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _inGameGuildKeyMapper = inGameGuildKeyMapper;
            _gameCharacterKeyMapper = gameCharacterKeyMapper;
            _gameGuildKeyMapper = gameGuildKeyMapper;
        }
        
        public void Migrate()
        {
            var oldInGuilds = SourceDbContext.InGuilds.ToList();

            foreach (var oldInGuild in oldInGuilds)
            {
                var newEntity = new InGameGuild()
                {
                    Id = _inGameGuildKeyMapper.MapKey(oldInGuild.Id),
                    FromTime = oldInGuild.FromTime, 
                    EndTime = oldInGuild.EndTime, 
                    GameCharacterId = _gameCharacterKeyMapper.MapKey(oldInGuild.CharacterId),
                    GameGuildId = _gameGuildKeyMapper.MapKey(oldInGuild.GuildId)
                };

                TargetDbContext.InGameGuilds.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}