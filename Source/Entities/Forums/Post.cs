using System;
using LaDanse.Source.Entities.Identity;

namespace LaDanse.Source.Entities.Forums
{
    public partial class Post
    {
        public string Id { get; set; }

        public DateTime PostDate { get; set; }
        public string Message { get; set; }

        public int PosterId { get; set; }
        public virtual Account Poster { get; set; }

        public string TopicId { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
