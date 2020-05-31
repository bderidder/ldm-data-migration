using System;
using System.Linq;
using LaDanse.Migration.KeyMappers.Forums;
using LaDanse.Migration.KeyMappers.Identity;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.Forums;

namespace LaDanse.Migration.Migrations.Forums
{
    public class ForumMigration : BaseMigration, IMigration, IProjectionsMigration
    {
        private readonly ForumKeyMapper _forumKeyMapper;
        private readonly TopicKeyMapper _topicKeyMapper;
        private readonly UserKeyMapper _userKeyMapper;
        
        public ForumMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext, 
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
            var forums = SourceDbContext.Forums.ToList();

            foreach (var forum in forums)
            {
                var newEntity = new Forum()
                {
                    Id = _forumKeyMapper.MapKey(forum.Id),
                    Name = forum.Name,
                    Description = forum.Description
                };

                TargetDbContext.Forums.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
        
        public void MigrateProjections()
        {
            var forums = SourceDbContext.Forums.ToList();

            foreach (var oldForum in forums)
            {
                var newForum = TargetDbContext.Forums
                    .First(f => f.Id == _forumKeyMapper.MapKey(oldForum.Id));

                newForum.LastPostDate = oldForum.LastPostDate;
                newForum.LastPostPosterId = oldForum.LastPostPosterId != null ? _userKeyMapper.MapKey((int) oldForum.LastPostPosterId) : (Guid?) null;
                newForum.LastPostTopicId = oldForum.LastPostTopicId != null ? _topicKeyMapper.MapKey(oldForum.LastPostTopicId) : (Guid?) null;
            }

            TargetDbContext.SaveChanges();
        }
    }
}