using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.Forums;
using Migration.KeyMappers.Forums;
using Migration.KeyMappers.Identity;

namespace Migration.Migrations.Forums
{
    public class ForumLastVisitMigration : BaseMigration, IMigration
    {
        private readonly ForumLastVisitKeyMapper _forumLastVisitKeyMapper;
        private readonly UserKeyMapper _userKeyMapper;
        
        public ForumLastVisitMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext, 
            ForumLastVisitKeyMapper forumLastVisitKeyMapper, 
            UserKeyMapper userKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _forumLastVisitKeyMapper = forumLastVisitKeyMapper;
            _userKeyMapper = userKeyMapper;
        }
        
        public void Migrate()
        {
            var forumLastVisits = SourceDbContext.ForumLastVisits.ToList();

            foreach (var oldForumLastVisit in forumLastVisits)
            {
                var newEntity = new ForumLastVisit()
                {
                    Id = _forumLastVisitKeyMapper.MapKey(oldForumLastVisit.Id),
                    LastVisitDate = oldForumLastVisit.LastVisitDate,
                    UserId = _userKeyMapper.MapKey(oldForumLastVisit.AccountId)
                };

                TargetDbContext.ForumLastVisits.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}