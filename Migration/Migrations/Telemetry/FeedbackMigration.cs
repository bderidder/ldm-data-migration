using System.Linq;
using LaDanse.Migration.KeyMappers.Identity;
using LaDanse.Migration.KeyMappers.Telemetry;
using LaDanse.Source.MySql;
using LaDanse.Target.Entities.Telemetry;
using Target.Shared;

namespace LaDanse.Migration.Migrations.Telemetry
{
    public class FeedbackMigration : BaseMigration, IMigration
    {
        private readonly UserKeyMapper _userKeyMapper;
        private readonly FeedbackKeyMapper _feedbackKeyMapper;
    
        public FeedbackMigration(
            SourceDbContext sourceDbContext, 
            ITargetDbContext targetDbContext,
            UserKeyMapper userKeyMapper,
            FeedbackKeyMapper feedbackKeyMapper)
            :base(sourceDbContext, targetDbContext)
        {
            _userKeyMapper = userKeyMapper;
            _feedbackKeyMapper = feedbackKeyMapper;
        }

        public void Migrate()
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