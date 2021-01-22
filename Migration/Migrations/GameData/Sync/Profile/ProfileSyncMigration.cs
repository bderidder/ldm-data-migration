using System.Linq;
using LaDanse.Migration.KeyMappers.GameData.Sync;
using LaDanse.Migration.KeyMappers.Identity;
using LaDanse.Source;
using LaDanse.Source.MySql;
using LaDanse.Target;
using LaDanse.Target.Entities.GameData.Sync.Profile;
using Target.Shared;

namespace LaDanse.Migration.Migrations.GameData.Sync.Profile
{
    public class ProfileSyncMigration : BaseMigration, IMigration
    {
        private readonly GameCharacterSourceKeyMapper _profileSyncKeyMapper;
        private readonly UserKeyMapper _userKeyMapper;
        
        public ProfileSyncMigration(
            SourceDbContext sourceDbContext, ITargetDbContext targetDbContext, 
            GameCharacterSourceKeyMapper profileSyncKeyMapper, 
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