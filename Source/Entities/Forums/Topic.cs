using System;
using LaDanse.Source.Entities.Identity;

namespace LaDanse.Source.Entities.Forums
{
    public partial class Topic
    {
        public Guid Id { get; set; }

        public DateTime PostDate { get; set; }
        public string Subject { get; set; }
        public DateTime? LastPostDate { get; set; }

        public Guid ForumId { get; set; }
        public virtual Forum Forum { get; set; }

        public int? LastPostPosterId { get; set; }
        public virtual Account LastPostPoster { get; set; }

        public int PosterId { get; set; }
        public virtual Account Poster { get; set; }
    }
}
