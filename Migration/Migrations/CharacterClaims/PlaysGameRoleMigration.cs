using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.CharacterClaims;
using Migration.KeyMappers.CharacterClaims;
using Migration.Migrations.GameData;

namespace Migration.Migrations.CharacterClaims
{
    public class PlaysGameRoleMigration : BaseMigration, IMigration
    {
        private readonly GameCharacterClaimKeyMapper _gameCharacterClaimKeyMapper;
        private readonly PlaysGameRoleKeyMapper _playsGameRoleKeyMapper;
        
        public PlaysGameRoleMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext,
            GameCharacterClaimKeyMapper gameCharacterClaimKeyMapper,
            PlaysGameRoleKeyMapper playsGameRoleKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _gameCharacterClaimKeyMapper = gameCharacterClaimKeyMapper;
            _playsGameRoleKeyMapper = playsGameRoleKeyMapper;
        }
        
        public void Migrate()
        {
            var playsRoles = SourceDbContext.PlaysRoles.ToList();

            foreach (var playsRole in playsRoles)
            {
                var newEntity = new PlaysGameRole()
                {
                    Id = _playsGameRoleKeyMapper.MapKey(playsRole.Id), 
                    FromTime = playsRole.FromTime, 
                    EndTime = playsRole.EndTime, 
                    GameRole = StringToGameRole.Convert(playsRole.Role),
                    GameCharacterClaimId = _gameCharacterClaimKeyMapper.MapKey(playsRole.CharacterClaimId)
                };

                TargetDbContext.PlaysGameRoles.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}