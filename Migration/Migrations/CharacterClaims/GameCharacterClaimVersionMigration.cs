using System.Linq;
using LaDanse.Migration.KeyMappers.CharacterClaims;
using LaDanse.Source;
using LaDanse.Source.MySql;
using LaDanse.Target;
using LaDanse.Target.Entities.CharacterClaims;
using Target.Shared;

namespace LaDanse.Migration.Migrations.CharacterClaims
{
    public class GameCharacterClaimVersionMigration : BaseMigration, IMigration
    {
        private readonly GameCharacterClaimKeyMapper _gameCharacterClaimKeyMapper;
        private readonly GameCharacterClaimVersionKeyMapper _gameCharacterClaimVersionKeyMapper;
        
        public GameCharacterClaimVersionMigration(
            SourceDbContext sourceDbContext, ITargetDbContext targetDbContext,
            GameCharacterClaimKeyMapper gameCharacterClaimKeyMapper,
            GameCharacterClaimVersionKeyMapper gameCharacterClaimVersionKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _gameCharacterClaimKeyMapper = gameCharacterClaimKeyMapper;
            _gameCharacterClaimVersionKeyMapper = gameCharacterClaimVersionKeyMapper;
        }
        
        public void Migrate()
        {
            var characterClaimVersions = SourceDbContext.CharacterClaimVersions.ToList();

            foreach (var characterClaimVersion in characterClaimVersions)
            {
                var newClaim = new GameCharacterClaimVersion()
                {
                    Id = _gameCharacterClaimVersionKeyMapper.MapKey(characterClaimVersion.Id), 
                    FromTime = characterClaimVersion.FromTime, 
                    EndTime = characterClaimVersion.EndTime, 
                    Comment = characterClaimVersion.Comment,
                    IsRaider = characterClaimVersion.Raider,
                    GameCharacterClaimId = _gameCharacterClaimKeyMapper.MapKey(characterClaimVersion.CharacterClaimId)
                };

                TargetDbContext.GameCharacterClaimVersions.Add(newClaim);
            }

            TargetDbContext.SaveChanges();
        }
    }
}