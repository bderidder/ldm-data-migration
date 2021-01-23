using System;
using LaDanse.Target.Entities.Shared;
using Microsoft.AspNetCore.Identity;

namespace LaDanse.Target.Entities.Identity
{
    public partial class User : IdentityUser<Guid>, IBaseEntity<Guid>
    {
        public string DisplayName { get; set; }
        public DateTime? LastLogin { get; set; }

        public string PasswordSalt { get; set; }
    }
}
