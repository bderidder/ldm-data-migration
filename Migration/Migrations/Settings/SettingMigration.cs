using System.Linq;
using LaDanse.Migration.KeyMappers.Identity;
using LaDanse.Migration.KeyMappers.Settings;
using LaDanse.Source.MySql;
using LaDanse.Target.Entities.Settings;
using Target.Shared;

namespace LaDanse.Migration.Migrations.Settings
{
    public class SettingMigration : BaseMigration, IMigration
    {
        private readonly SettingKeyMapper _settingKeyMapper;
        private readonly UserKeyMapper _userKeyMapper;
        
        public SettingMigration(
            SourceDbContext sourceDbContext, ITargetDbContext targetDbContext,
            UserKeyMapper userKeyMapper, SettingKeyMapper settingKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _userKeyMapper = userKeyMapper;
            _settingKeyMapper = settingKeyMapper;
        }
        
        public void Migrate()
        {
            var oldSettings = SourceDbContext.Settings.ToList();

            foreach (var oldSetting in oldSettings)
            {
                var newEntity = new Setting()
                {
                    Id = _settingKeyMapper.MapKey(oldSetting.Id),
                    Name = oldSetting.Name,
                    Value = oldSetting.Value,
                    UserId = _userKeyMapper.MapKey(oldSetting.AccountId)
                };

                TargetDbContext.Settings.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}