using System;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.Identity
{
    public partial class User : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public DateTime? LastLogin { get; set; }

        public string Salt { get; set; }
        public string Password { get; set; }
    }
}
