using System;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.Comments
{
    public partial class CommentGroup : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime PostDate { get; set; }
    }
}
