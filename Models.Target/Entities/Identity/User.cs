﻿﻿using System;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.Identity
{
    public partial class User : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        
        public string ExternalId { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        
        public bool DisplayNameByUser { get; set; }
    }
}
