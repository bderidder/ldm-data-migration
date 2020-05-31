namespace LaDanse.Migration.Migrations.Queues
{
    public class AllQueuesMigrations : IMigration
    {
        private readonly ActivityQueueItemMigration _activityQueueItemMigration;
        private readonly NotificationQueueItemMigration _notificationQueueItemMigration;
        
        public AllQueuesMigrations(
            ActivityQueueItemMigration activityQueueItemMigration, 
            NotificationQueueItemMigration notificationQueueItemMigration)
        {
            _activityQueueItemMigration = activityQueueItemMigration;
            _notificationQueueItemMigration = notificationQueueItemMigration;
        }
        
        public void Migrate()
        {
            _activityQueueItemMigration.Migrate();
            _notificationQueueItemMigration.Migrate();
        }
    }
}