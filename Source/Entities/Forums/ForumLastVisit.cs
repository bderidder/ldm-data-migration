using System;
using LaDanse.Source.Entities.Identity;

namespace LaDanse.Source.Entities.Forums
{
    public partial class ForumLastVisit
    {
        public Guid Id { get; set; }

        public DateTime LastVisitDate { get; set; }

        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
