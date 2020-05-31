using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.Forums;
using Migration.KeyMappers.Forums;
using Migration.KeyMappers.Identity;

namespace Migration.Migrations.Forums
{
    public class UnreadPostMigration : BaseMigration
    {
        private readonly UnreadPostKeyMapper _unreadPostKeyMapper;
        private readonly PostKeyMapper _postKeyMapper;
        private readonly UserKeyMapper _userKeyMapper;
        
        public UnreadPostMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext, 
            UnreadPostKeyMapper unreadPostKeyMapper, 
            PostKeyMapper postKeyMapper, 
            UserKeyMapper userKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _unreadPostKeyMapper = unreadPostKeyMapper;
            _postKeyMapper = postKeyMapper;
            _userKeyMapper = userKeyMapper;
        }
        
        public override void Migrate()
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