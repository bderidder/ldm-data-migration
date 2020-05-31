using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.Telemetry;
using Migration.KeyMappers.Identity;
using Migration.KeyMappers.Telemetry;

namespace Migration.Migrations
{
    public class FeedbackMigration : BaseMigration
    {
        private readonly UserKeyMapper _userKeyMapper;
        private readonly FeedbackKeyMapper _feedbackKeyMapper;
    
        public FeedbackMigration(
            SourceDbContext sourceDbContext, 
            TargetDbContext targetDbContext,
            UserKeyMapper userKeyMapper,
            FeedbackKeyMapper feedbackKeyMapper)
            :base(sourceDbContext, targetDbContext)
        {
            _userKeyMapper = userKeyMapper;
            _feedbackKeyMapper = feedbackKeyMapper;
        }

        public override void Migrate()
        {
            var feedbacks = SourceDbContext.Feedbacks.ToList();

            foreach (var feedback in feedbacks)
            {
                var migratedFeedback = new Feedback()
                {
                    Id = _feedbackKeyMapper.MapKey(feedback.Id), 
                    PostedOn = feedback.PostedOn, 
                    Content = feedback.Content, 
                    PostedById = _userKeyMapper.MapKey(feedback.PostedById)
                };

                TargetDbContext.Feedbacks.Add(migratedFeedback);
            }

            TargetDbContext.SaveChanges();
        }
    }
}