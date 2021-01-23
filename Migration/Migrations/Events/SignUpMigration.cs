using System.Linq;
using LaDanse.Migration.KeyMappers.Events;
using LaDanse.Migration.KeyMappers.Identity;
using LaDanse.Source.MySql;
using LaDanse.Target.Entities.Events;
using Target.Shared;

namespace LaDanse.Migration.Migrations.Events
{
    public class SignUpMigration : BaseMigration, IMigration
    {
        private readonly SignUpKeyMapper _signUpKeyMapper;
        private readonly EventKeyMapper _eventKeyMapper;
        private readonly UserKeyMapper _userKeyMapper;
        
        public SignUpMigration(
            SourceDbContext sourceDbContext, ITargetDbContext targetDbContext, 
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