using System.Linq;
using LaDanse.Source;
using LaDanse.Target;
using LaDanse.Target.Entities.Events;
using Migration.KeyMappers.Comments;
using Migration.KeyMappers.Events;
using Migration.KeyMappers.Identity;

namespace Migration.Migrations.Events
{
    public class EventMigration : BaseMigration
    {
        private readonly EventKeyMapper _eventKeyMapper;
        private readonly CommentGroupKeyMapper _commentGroupKeyMapper;
        private readonly UserKeyMapper _userKeyMapper;
        
        public EventMigration(
            SourceDbContext sourceDbContext, TargetDbContext targetDbContext, 
            EventKeyMapper eventKeyMapper, 
            CommentGroupKeyMapper commentGroupKeyMapper, 
            UserKeyMapper userKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _eventKeyMapper = eventKeyMapper;
            _commentGroupKeyMapper = commentGroupKeyMapper;
            _userKeyMapper = userKeyMapper;
        }
        
        public override void Migrate()
        {
            var events = SourceDbContext.Events.ToList();

            foreach (var oldEvent in events)
            {
                var newEntity = new Event()
                {
                    Id = _eventKeyMapper.MapKey(oldEvent.Id),
                    InviteTime = oldEvent.InviteTime,
                    StartTime = oldEvent.StartTime,
                    EndTime = oldEvent.EndTime,
                    Name = oldEvent.Name,
                    Description = oldEvent.Description,
                    State = StringToEventState.Convert(oldEvent.State),
                    CommentGroupId = _commentGroupKeyMapper.MapKey(oldEvent.CommentGroupId), 
                    OrganiserId = _userKeyMapper.MapKey(oldEvent.OrganiserId)
                };

                TargetDbContext.Events.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}