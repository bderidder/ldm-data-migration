using System.Linq;
using LaDanse.Migration.KeyMappers.Identity;
using LaDanse.Migration.KeyMappers.Settings;
using LaDanse.Source.MySql;
using LaDanse.Target.Entities.Settings;
using Target.Shared;

namespace LaDanse.Migration.Migrations.Settings
{
    public class FeatureToggleMigration : BaseMigration, IMigration
    {
        private readonly FeatureToggleKeyMapper _featureToggleKeyMapper;
        private readonly UserKeyMapper _userKeyMapper;
        
        public FeatureToggleMigration(
            SourceDbContext sourceDbContext, ITargetDbContext targetDbContext, 
            UserKeyMapper userKeyMapper, FeatureToggleKeyMapper featureToggleKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _userKeyMapper = userKeyMapper;
            _featureToggleKeyMapper = featureToggleKeyMapper;
        }
        
        public void Migrate()
        {
            var oldFeatureToggles = SourceDbContext.FeatureToggles.ToList();

            foreach (var oldFeatureToggle in oldFeatureToggles)
            {
                var newEntity = new FeatureToggle()
                {
                    Id = _featureToggleKeyMapper.MapKey(oldFeatureToggle.Id),
                    Feature = oldFeatureToggle.Feature,
                    Toggle = oldFeatureToggle.Toggle,
                    UserId = _userKeyMapper.MapKey(oldFeatureToggle.ToggleForId)
                };

                TargetDbContext.FeatureToggles.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}