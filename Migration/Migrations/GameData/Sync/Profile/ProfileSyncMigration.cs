using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.GameData.Sync.Profile;
using Migration.KeyMappers.GameData.Core;
using Migration.KeyMappers.Identity;

namespace Migration.Migrations.GameData.Sync.Profile
{
    public class ProfileSyncMigration : BaseMigration, IMigration
    {
        private readonly ProfileSyncKeyMapper _profileSyncKeyMapper;
        private readonly UserKeyMapper _userKeyMapper;
        
        public ProfileSyncMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext, 
            ProfileSyncKeyMapper profileSyncKeyMapper, 
            UserKeyMapper userKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _profileSyncKeyMapper = profileSyncKeyMapper;
            _userKeyMapper = userKeyMapper;
        }
        
        public void Migrate()
        {
            var profileSyncs = SourceDbContext.ProfileSyncs.ToList();

            foreach (var profileSync in profileSyncs)
            {
                var newEntity = new ProfileSync()
                {
                    Id = _profileSyncKeyMapper.MapKey(profileSync.Id), 
                    UserId = _userKeyMapper.MapKey(profileSync.AccountId)
                };

                TargetDbContext.ProfileSyncs.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}