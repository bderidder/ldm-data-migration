using System.Linq;
using LaDanse.Migration.KeyMappers.Identity;
using LaDanse.Source.MySql;
using LaDanse.Target.Entities.Identity;
using Target.Shared;

namespace LaDanse.Migration.Migrations.Identity
{
    public class UserMigration : BaseMigration, IMigration
    {
        private readonly UserKeyMapper _userKeyMapper;
    
        public UserMigration(
            SourceDbContext sourceDbContext, 
            ITargetDbContext targetDbContext,
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
                    UserName = account.Username,
                    NormalizedUserName = account.UsernameCanonical,
                    Email = account.Email,
                    NormalizedEmail = account.EmailCanonical,
                    EmailConfirmed = true,
                    PasswordSalt = account.Salt,
                    PasswordHash = account.Password,
                    LastLogin = account.LastLogin,
                    SecurityStamp = null,
                    ConcurrencyStamp = null,
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                };

                TargetDbContext.Users.Add(user);
            }

            TargetDbContext.SaveChanges();
        }
    }
}