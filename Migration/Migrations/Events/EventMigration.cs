using System.Linq;
using LaDanse.Migration.KeyMappers.Comments;
using LaDanse.Migration.KeyMappers.Events;
using LaDanse.Migration.KeyMappers.Identity;
using LaDanse.Source.MySql;
using LaDanse.Target.Entities.Events;
using Target.Shared;

namespace LaDanse.Migration.Migrations.Events
{
    public class EventMigration : BaseMigration, IMigration
    {
        private readonly EventKeyMapper _eventKeyMapper;
        private readonly CommentGroupKeyMapper _commentGroupKeyMapper;
        private readonly UserKeyMapper _userKeyMapper;
        
        public EventMigration(
            SourceDbContext sourceDbContext, ITargetDbContext targetDbContext, 
            EventKeyMapper eventKeyMapper, 
            CommentGroupKeyMapper commentGroupKeyMapper, 
            UserKeyMapper userKeyMapper)
            : base(sourceDbContext, targetDbContext)
        {
            _eventKeyMapper = eventKeyMapper;
            _commentGroupKeyMapper = commentGroupKeyMapper;
            _userKeyMapper = userKeyMapper;
        }
        
        public void Migrate()
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
                    OrganiserId = _userKeyMapper.MapKey(oldEvent.OrganiserId),
                    LastModifiedTime = oldEvent.LastModifiedTime
                };

                TargetDbContext.Events.Add(newEntity);
            }

            TargetDbContext.SaveChanges();
        }
    }
}