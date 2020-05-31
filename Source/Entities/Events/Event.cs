using System;
using LaDanse.Source.Entities.Comments;
using LaDanse.Source.Entities.Identity;

namespace LaDanse.Source.Entities.Events
{
    public partial class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime InviteTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public string State { get; set; }

        public string CommentGroupId { set; get; }
        public CommentGroup CommentGroup { set; get; }

        public int OrganiserId { get; set; }
        public virtual Account Organiser { get; set; }
    }
}
