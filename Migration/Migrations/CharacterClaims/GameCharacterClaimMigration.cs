using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.CharacterClaims;
using Microsoft.Extensions.Logging;
using Migration.KeyMappers.CharacterClaims;
using Migration.KeyMappers.GameData.Characters;
using Migration.KeyMappers.Identity;

namespace Migration.Migrations.CharacterClaims
{
    public class GameCharacterClaimMigration : BaseMigration, IMigration
    {
        private readonly ILogger<GameCharacterClaimMigration> _logger;
        private readonly UserKeyMapper _userKeyMapper;
        private readonly GameCharacterKeyMapper _gameCharacterKeyMapper;
        private readonly GameCharacterClaimKeyMapper _gameCharacterClaimKeyMapper;

        private bool _hasAlreadyRun = false;
        
        public GameCharacterClaimMigration(
            ILogger<GameCharacterClaimMigration> logger,
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext,
            UserKeyMapper userKeyMapper,
            GameCharacterKeyMapper gameCharacterKeyMapper,
            GameCharacterClaimKeyMapper gameCharacterClaimKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _logger = logger;
            _userKeyMapper = userKeyMapper;
            _gameCharacterKeyMapper = gameCharacterKeyMapper;
            _gameCharacterClaimKeyMapper = gameCharacterClaimKeyMapper;
        }
        
        public void Migrate()
        {
            if (_hasAlreadyRun)
            {
                _logger.LogError("GameCharacterClaimMigration is being run a second time. That should never happen.");
            }
            
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
                
                _logger.LogInformation($"Mapped {claim.Id} to {newClaim.Id}");

                TargetDbContext.GameCharacterClaims.Add(newClaim);
            }

            TargetDbContext.SaveChanges();

            _hasAlreadyRun = true;
            
            _logger.LogInformation("Finished migrating GameCharacterClaimMigration");
        }
    }
}