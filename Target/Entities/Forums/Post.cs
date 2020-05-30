using System;
using LaDanse.Target.Entities.Identity;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.Forums
{
    public partial class Post : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public DateTime PostDate { get; set; }
        public string Message { get; set; }

        public Guid PosterId { get; set; }
        public virtual User Poster { get; set; }

        public Guid TopicId { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
