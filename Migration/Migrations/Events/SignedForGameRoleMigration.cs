using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.Events;
using Migration.KeyMappers.Events;
using Migration.Migrations.GameData;

namespace Migration.Migrations.Events
{
    public class SignedForGameRoleMigration : BaseMigration
    {
        private readonly SignedForGameRoleKeyMapper _signedForGameRoleKeyMapper;
        private readonly SignUpKeyMapper _signUpKeyMapper;
        
        public SignedForGameRoleMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext, 
            SignedForGameRoleKeyMapper signedForGameRoleKeyMapper, 
            SignUpKeyMapper signUpKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _signedForGameRoleKeyMapper = signedForGameRoleKeyMapper;
            _signUpKeyMapper = signUpKeyMapper;
        }
        
        public override void Migrate()
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