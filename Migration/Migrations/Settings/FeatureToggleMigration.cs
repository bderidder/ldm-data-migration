using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.Settings;
using Migration.KeyMappers.Identity;
using Migration.KeyMappers.Settings;

namespace Migration.Migrations.Settings
{
    public class FeatureToggleMigration : BaseMigration, IMigration
    {
        private readonly FeatureToggleKeyMapper _featureToggleKeyMapper;
        private readonly UserKeyMapper _userKeyMapper;
        
        public FeatureToggleMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext, 
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