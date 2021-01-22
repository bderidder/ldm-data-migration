using System;
using System.Linq;
using LaDanse.Migration.KeyMappers.Forums;
using LaDanse.Migration.KeyMappers.Identity;
using LaDanse.Source;
using LaDanse.Source.MySql;
using LaDanse.Target;
using LaDanse.Target.Entities.Forums;
using Target.Shared;

namespace LaDanse.Migration.Migrations.Forums
{
    public class TopicMigration : BaseMigration, IMigration, IProjectionsMigration
    {
        private readonly ForumKeyMapper _forumKeyMapper;
        private readonly TopicKeyMapper _topicKeyMapper;
        private readonly UserKeyMapper _userKeyMapper;
        
        public TopicMigration(
            SourceDbContext sourceDbContext, ITargetDbContext targetDbContext, 
            ForumKeyMapper forumKeyMapper, 
            TopicKeyMapper topicKeyMapper, 
            UserKeyMapper userKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _forumKeyMapper = forumKeyMapper;
            _topicKeyMapper = topicKeyMapper;
            _userKeyMapper = userKeyMapper;
        }
        
        public void Migrate()
        {
            var topics = SourceDbContext.Topics.ToList();

            foreach (var oldTopic in topics)
            {
                var newEntity = new Topic()
                {
                    Id = _topicKeyMapper.MapKey(oldTopic.Id),
                    PostDate = oldTopic.PostDate,
                    Subject = oldTopic.Subject,
                    ForumId = _forumKeyMapper.MapKey(oldTopic.ForumId),
                    PosterId = _userKeyMapper.MapKey(oldTopic.PosterId)
                };

                TargetDbContext.Topics.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
        
        public void MigrateProjections()
        {
            var topics = SourceDbContext.Topics.ToList();

            foreach (var oldTopic in topics)
            {
                var newForum = TargetDbContext.Topics
                    .First(f => f.Id == _topicKeyMapper.MapKey(oldTopic.Id));

                newForum.LastPostDate = oldTopic.LastPostDate;
                newForum.LastPostPosterId = oldTopic.LastPostPosterId != null ? _userKeyMapper.MapKey((int) oldTopic.LastPostPosterId) : (Guid?) null;
            }

            TargetDbContext.SaveChanges();
        }
    }
}