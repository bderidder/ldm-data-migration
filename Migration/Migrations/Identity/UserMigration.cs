using System;
using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.Identity;
using Migration.KeyMappers;
using Migration.KeyMappers.Identity;

namespace Migration.Migrations
{
    public class UserMigration : BaseMigration
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

        public override void Migrate()
        {
            var accounts = SourceDbContext.Accounts.ToList();

            foreach (var account in accounts)
            {
                var user = new User
                {
                    Id = _userKeyMapper.MapKey(account.Id), 
                    ExternalId = Guid.NewGuid().ToString(), 
                    DisplayName = account.DisplayName, 
                    Email = account.Email
                };

                TargetDbContext.Users.Add(user);
            }

            TargetDbContext.SaveChanges();
        }
    }
}