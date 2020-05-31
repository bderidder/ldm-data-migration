using System.Linq;
using LaDanse.Migration.KeyMappers.Forums;
using LaDanse.Migration.KeyMappers.Identity;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.Forums;

namespace LaDanse.Migration.Migrations.Forums
{
    public class PostMigration : BaseMigration, IMigration
    {
        private readonly PostKeyMapper _postKeyMapper;
        private readonly TopicKeyMapper _topicKeyMapper;
        private readonly UserKeyMapper _userKeyMapper;
        
        public PostMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext, 
            TopicKeyMapper topicKeyMapper, 
            UserKeyMapper userKeyMapper, 
            PostKeyMapper postKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _topicKeyMapper = topicKeyMapper;
            _userKeyMapper = userKeyMapper;
            _postKeyMapper = postKeyMapper;
        }
        
        public void Migrate()
        {
            var posts = SourceDbContext.Posts.ToList();

            foreach (var oldPost in posts)
            {
                var newEntity = new Post()
                {
                    Id = _postKeyMapper.MapKey(oldPost.Id),
                    PostDate = oldPost.PostDate,
                    Content = oldPost.Message,
                    PosterId = _userKeyMapper.MapKey(oldPost.PosterId),
                    TopicId = _topicKeyMapper.MapKey(oldPost.TopicId)
                };

                TargetDbContext.Posts.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}