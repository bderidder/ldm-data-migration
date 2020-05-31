using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.Events;
using Migration.KeyMappers.Events;
using Migration.KeyMappers.Identity;

namespace Migration.Migrations.Events
{
    public class SignUpMigration : BaseMigration, IMigration
    {
        private readonly SignUpKeyMapper _signUpKeyMapper;
        private readonly EventKeyMapper _eventKeyMapper;
        private readonly UserKeyMapper _userKeyMapper;
        
        public SignUpMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext, 
            SignUpKeyMapper signUpKeyMapper, 
            EventKeyMapper eventKeyMapper, 
            UserKeyMapper userKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _signUpKeyMapper = signUpKeyMapper;
            _eventKeyMapper = eventKeyMapper;
            _userKeyMapper = userKeyMapper;
        }
        
        public void Migrate()
        {
            var signUps = SourceDbContext.SignUps.ToList();

            foreach (var signUp in signUps)
            {
                var newEntity = new SignUp()
                {
                    Id = _signUpKeyMapper.MapKey(signUp.Id),
                    Type = StringToSignUpType.Convert(signUp.Type),
                    EventId = _eventKeyMapper.MapKey(signUp.EventId), 
                    UserId = _userKeyMapper.MapKey(signUp.AccountId)
                };

                TargetDbContext.SignUps.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}