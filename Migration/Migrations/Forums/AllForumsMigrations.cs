namespace Migration.Migrations.Forums
{
    public class AllForumsMigrations : IMigration
    {
        private readonly ForumMigration _forumMigration;
        private readonly TopicMigration _topicMigration;
        private readonly PostMigration _postMigration;
        private readonly ForumLastVisitMigration _forumLastVisitMigration;
        private readonly UnreadPostMigration _unreadPostMigration;
        
        public AllForumsMigrations(
            ForumMigration forumMigration, 
            TopicMigration topicMigration, 
            PostMigration postMigration, 
            ForumLastVisitMigration forumLastVisitMigration, 
            UnreadPostMigration unreadPostMigration)
        {
            _forumMigration = forumMigration;
            _topicMigration = topicMigration;
            _postMigration = postMigration;
            _forumLastVisitMigration = forumLastVisitMigration;
            _unreadPostMigration = unreadPostMigration;
        }
        
        public void Migrate()
        {
            _forumMigration.Migrate();
            _topicMigration.Migrate();
            _postMigration.Migrate();
            _forumLastVisitMigration.Migrate();
            _unreadPostMigration.Migrate();
            
            _forumMigration.MigrateProjections();
            _topicMigration.MigrateProjections();
        }
    }
}