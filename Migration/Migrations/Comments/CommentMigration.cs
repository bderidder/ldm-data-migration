using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.Comments;
using Migration.KeyMappers.Comments;
using Migration.KeyMappers.Identity;

namespace Migration.Migrations.Comments
{
    public class CommentMigration : BaseMigration, IMigration
    {
        private readonly CommentKeyMapper _commentKeyMapper;
        private readonly CommentGroupKeyMapper _commentGroupKeyMapper;
        private readonly UserKeyMapper _userKeyMapper;
        
        public CommentMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext, 
            CommentKeyMapper commentKeyMapper, 
            CommentGroupKeyMapper commentGroupKeyMapper, 
            UserKeyMapper userKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _commentKeyMapper = commentKeyMapper;
            _commentGroupKeyMapper = commentGroupKeyMapper;
            _userKeyMapper = userKeyMapper;
        }
        
        public void Migrate()
        {
            var comments = SourceDbContext.Comments.ToList();

            foreach (var comment in comments)
            {
                var newEntity = new Comment()
                {
                    Id = _commentKeyMapper.MapKey(comment.Id),
                    PostDate = comment.PostDate,
                    Content = comment.Message,
                    GroupId = _commentGroupKeyMapper.MapKey(comment.GroupId), 
                    PosterId = _userKeyMapper.MapKey(comment.PosterId)
                };

                TargetDbContext.Comments.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}