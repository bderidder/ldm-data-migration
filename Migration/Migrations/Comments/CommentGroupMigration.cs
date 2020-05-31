using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.Comments;
using Migration.KeyMappers.Comments;

namespace Migration.Migrations.Comments
{
    public class CommentGroupMigration : BaseMigration
    {
        private readonly CommentGroupKeyMapper _commentGroupKeyMapper;
        
        public CommentGroupMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext, 
            CommentGroupKeyMapper commentGroupKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _commentGroupKeyMapper = commentGroupKeyMapper;
        }
        
        public override void Migrate()
        {
            var commentGroups = SourceDbContext.CommentGroups.ToList();

            foreach (var commentGroup in commentGroups)
            {
                var newEntity = new CommentGroup()
                {
                    Id = _commentGroupKeyMapper.MapKey(commentGroup.Id),
                    PostDate = commentGroup.PostDate
                };

                TargetDbContext.CommentGroups.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}