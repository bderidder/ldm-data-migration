using System.Linq;
using LaDanse.Migration.KeyMappers.Events;
using LaDanse.Migration.Migrations.GameData;
using LaDanse.Source;
using LaDanse.Source.MySql;
using LaDanse.Target;
using LaDanse.Target.Entities.Events;
using Target.Shared;

namespace LaDanse.Migration.Migrations.Events
{
    public class SignedForGameRoleMigration : BaseMigration, IMigration
    {
        private readonly SignedForGameRoleKeyMapper _signedForGameRoleKeyMapper;
        private readonly SignUpKeyMapper _signUpKeyMapper;
        
        public SignedForGameRoleMigration(
            SourceDbContext sourceDbContext, ITargetDbContext targetDbContext, 
            SignedForGameRoleKeyMapper signedForGameRoleKeyMapper, 
            SignUpKeyMapper signUpKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _signedForGameRoleKeyMapper = signedForGameRoleKeyMapper;
            _signUpKeyMapper = signUpKeyMapper;
        }
        
        public void Migrate()
        {
            var forRoles = SourceDbContext.ForRoles.ToList();

            foreach (var forRole in forRoles)
            {
                var newEntity = new SignedForGameRole()
                {
                    Id = _signedForGameRoleKeyMapper.MapKey(forRole.Id),
                    GameRole = StringToGameRole.Convert(forRole.Role),
                    SignUpId = _signUpKeyMapper.MapKey(forRole.SignUpId)
                };

                TargetDbContext.SignedForGameRoles.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}