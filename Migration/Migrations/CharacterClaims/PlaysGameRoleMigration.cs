using System.Linq;
using LaDanse.Migration.KeyMappers.CharacterClaims;
using LaDanse.Migration.Migrations.GameData;
using LaDanse.Source.MySql;
using LaDanse.Target.Entities.CharacterClaims;
using Target.Shared;

namespace LaDanse.Migration.Migrations.CharacterClaims
{
    public class PlaysGameRoleMigration : BaseMigration, IMigration
    {
        private readonly GameCharacterClaimKeyMapper _gameCharacterClaimKeyMapper;
        private readonly PlaysGameRoleKeyMapper _playsGameRoleKeyMapper;
        
        public PlaysGameRoleMigration(
            SourceDbContext sourceDbContext, ITargetDbContext targetDbContext,
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