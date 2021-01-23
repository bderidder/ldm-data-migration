using System.Linq;
using LaDanse.Migration.KeyMappers.CharacterClaims;
using LaDanse.Migration.KeyMappers.GameData.Characters;
using LaDanse.Migration.KeyMappers.Identity;
using LaDanse.Source.MySql;
using LaDanse.Target.Entities.CharacterClaims;
using Target.Shared;

namespace LaDanse.Migration.Migrations.CharacterClaims
{
    public class GameCharacterClaimMigration : BaseMigration, IMigration
    {
        private readonly UserKeyMapper _userKeyMapper;
        private readonly GameCharacterKeyMapper _gameCharacterKeyMapper;
        private readonly GameCharacterClaimKeyMapper _gameCharacterClaimKeyMapper;
        
        public GameCharacterClaimMigration(
            SourceDbContext sourceDbContext, ITargetDbContext targetDbContext,
            UserKeyMapper userKeyMapper,
            GameCharacterKeyMapper gameCharacterKeyMapper,
            GameCharacterClaimKeyMapper gameCharacterClaimKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _userKeyMapper = userKeyMapper;
            _gameCharacterKeyMapper = gameCharacterKeyMapper;
            _gameCharacterClaimKeyMapper = gameCharacterClaimKeyMapper;
        }
        
        public void Migrate()
        {
            var claims = SourceDbContext.CharacterClaims.ToList();

            foreach (var claim in claims)
            {
                var newClaim = new GameCharacterClaim()
                {
                    Id = _gameCharacterClaimKeyMapper.MapKey(claim.Id), 
                    FromTime = claim.FromTime, 
                    EndTime = claim.EndTime, 
                    UserId = _userKeyMapper.MapKey(claim.AccountId),
                    GameCharacterId = _gameCharacterKeyMapper.MapKey(claim.CharacterId)
                };

                TargetDbContext.GameCharacterClaims.Add(newClaim);
            }

            TargetDbContext.SaveChanges();
        }
    }
}