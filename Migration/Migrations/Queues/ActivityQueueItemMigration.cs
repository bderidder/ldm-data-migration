using System;
using System.Linq;
using LaDanse.Migration.KeyMappers.Identity;
using LaDanse.Migration.KeyMappers.Queues;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.Queues;

namespace LaDanse.Migration.Migrations.Queues
{
    public class ActivityQueueItemMigration : BaseMigration, IMigration
    {
        private readonly ActivityQueueItemKeyMapper _activityQueueItemKeyMapper;
        private readonly UserKeyMapper _userKeyMapper;
        
        public ActivityQueueItemMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext,
            UserKeyMapper userKeyMapper, 
            ActivityQueueItemKeyMapper activityQueueItemKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _userKeyMapper = userKeyMapper;
            _activityQueueItemKeyMapper = activityQueueItemKeyMapper;
        }
        
        public void Migrate()
        {
            var oldActivityQueueItems = SourceDbContext.ActivityQueueItems.ToList();

            foreach (var oldActivityQueueItem in oldActivityQueueItems)
            {
                var newEntity = new ActivityQueueItem()
                {
                    Id = _activityQueueItemKeyMapper.MapKey(oldActivityQueueItem.Id),
                    ActivityType = oldActivityQueueItem.ActivityType,
                    ActivityOn = oldActivityQueueItem.ActivityOn,
                    RawData = oldActivityQueueItem.RawData,
                    ProcessedOn = oldActivityQueueItem.ProcessedOn,
                    ActivityById = oldActivityQueueItem.ActivityById != null ? _userKeyMapper.MapKey((int) oldActivityQueueItem.ActivityById) : (Guid?) null
                };

                TargetDbContext.ActivityQueueItems.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}