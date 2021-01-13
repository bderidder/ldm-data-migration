using System;
using System.Linq;
using LaDanse.Migration.KeyMappers.Identity;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.Identity;

namespace LaDanse.Migration.Migrations.Identity
{
    public class UserMigration : BaseMigration, IMigration
    {
        private readonly UserKeyMapper _userKeyMapper;
    
        public UserMigration(
            SourceDbContext sourceDbContext, 
            TargetDbContext targetDbContext,
            UserKeyMapper userKeyMapper)
            :base(sourceDbContext, targetDbContext)
        {
            _userKeyMapper = userKeyMapper;
        }

        public void Migrate()
        {
            var accounts = SourceDbContext.Accounts.ToList();

            foreach (var account in accounts)
            {
                var user = new User
                {
                    Id = _userKeyMapper.MapKey(account.Id), 
                    DisplayName = account.DisplayName, 
                    Email = account.Email,
                    Salt = account.Salt,
                    Password = account.Password,
                    LastLogin = account.LastLogin
                };

                TargetDbContext.Users.Add(user);
            }

            TargetDbContext.SaveChanges();
        }
    }
}