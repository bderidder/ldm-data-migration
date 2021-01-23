using System;
using System.Linq;
using LaDanse.Migration.KeyMappers.Identity;
using LaDanse.Migration.KeyMappers.Telemetry;
using LaDanse.Source.MySql;
using LaDanse.Target.Entities.Telemetry;
using Target.Shared;

namespace LaDanse.Migration.Migrations.Telemetry
{
    public class FeatureUseMigration : BaseMigration, IMigration
    {
        private readonly UserKeyMapper _userKeyMapper;
        private readonly FeatureUseKeyMapper _featureUseKeyMapper;
    
        public FeatureUseMigration(
            SourceDbContext sourceDbContext, 
            ITargetDbContext targetDbContext,
            UserKeyMapper userKeyMapper, 
            FeatureUseKeyMapper featureUseKeyMapper)
            :base(sourceDbContext, targetDbContext)
        {
            _userKeyMapper = userKeyMapper;
            _featureUseKeyMapper = featureUseKeyMapper;
        }

        public void Migrate()
        {
            var oldFeatureUses = SourceDbContext.FeatureUses.ToList();

            foreach (var oldFeatureUse in oldFeatureUses)
            {
                var newEntity = new FeatureUse()
                {
                    Id = _featureUseKeyMapper.MapKey(oldFeatureUse.Id), 
                    UsedOn = oldFeatureUse.UsedOn, 
                    Feature = oldFeatureUse.Feature, 
                    RawData = oldFeatureUse.RawData, 
                    UsedById = oldFeatureUse.UsedById != null ? _userKeyMapper.MapKey((int) oldFeatureUse.UsedById) : (Guid?) null
                };

                TargetDbContext.FeatureUses.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}