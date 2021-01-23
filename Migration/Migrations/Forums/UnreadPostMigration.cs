using System.Linq;
using LaDanse.Migration.KeyMappers.Forums;
using LaDanse.Migration.KeyMappers.Identity;
using LaDanse.Source.MySql;
using LaDanse.Target.Entities.Forums;
using Target.Shared;

namespace LaDanse.Migration.Migrations.Forums
{
    public class UnreadPostMigration : BaseMigration, IMigration
    {
        private readonly UnreadPostKeyMapper _unreadPostKeyMapper;
        private readonly PostKeyMapper _postKeyMapper;
        private readonly UserKeyMapper _userKeyMapper;
        
        public UnreadPostMigration(
            SourceDbContext sourceDbContext, ITargetDbContext targetDbContext, 
            UnreadPostKeyMapper unreadPostKeyMapper, 
            PostKeyMapper postKeyMapper, 
            UserKeyMapper userKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _unreadPostKeyMapper = unreadPostKeyMapper;
            _postKeyMapper = postKeyMapper;
            _userKeyMapper = userKeyMapper;
        }
        
        public void Migrate()
        {
            var oldUnreadPosts = SourceDbContext.UnreadPosts.ToList();

            foreach (var oldUnreadPost in oldUnreadPosts)
            {
                var newEntity = new UnreadPost()
                {
                    Id = _unreadPostKeyMapper.MapKey(oldUnreadPost.Id),
                    PostId = _postKeyMapper.MapKey(oldUnreadPost.PostId),
                    UserId = _userKeyMapper.MapKey(oldUnreadPost.AccountId)
                };

                TargetDbContext.UnreadPosts.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}