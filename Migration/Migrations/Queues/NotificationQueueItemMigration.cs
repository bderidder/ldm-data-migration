using System;
using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.Queues;
using Migration.KeyMappers.Identity;
using Migration.KeyMappers.Queues;

namespace Migration.Migrations.Queues
{
    public class NotificationQueueItemMigration : BaseMigration, IMigration
    {
        private readonly NotificationQueueItemKeyMapper _notificationQueueItemKeyMapper;
        private readonly UserKeyMapper _userKeyMapper;
        
        public NotificationQueueItemMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext,
            UserKeyMapper userKeyMapper, 
            NotificationQueueItemKeyMapper notificationQueueItemKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _userKeyMapper = userKeyMapper;
            _notificationQueueItemKeyMapper = notificationQueueItemKeyMapper;
        }
        
        public void Migrate()
        {
            var oldNotificationQueueItems = SourceDbContext.NotificationQueueItems.ToList();

            foreach (var oldNotificationQueueItem in oldNotificationQueueItems)
            {
                var newEntity = new NotificationQueueItem()
                {
                    Id = _notificationQueueItemKeyMapper.MapKey(oldNotificationQueueItem.Id),
                    ActivityType = oldNotificationQueueItem.ActivityType,
                    ActivityOn = oldNotificationQueueItem.ActivityOn,
                    RawData = oldNotificationQueueItem.RawData,
                    ProcessedOn = oldNotificationQueueItem.ProcessedOn,
                    ActivityById = oldNotificationQueueItem.ActivityById != null ? _userKeyMapper.MapKey((int) oldNotificationQueueItem.ActivityById) : (Guid?) null
                };

                TargetDbContext.NotificationQueueItems.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}