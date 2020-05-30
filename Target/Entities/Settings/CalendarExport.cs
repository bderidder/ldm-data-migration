using System;
using LaDanse.Target.Entities.Identity;
using LaDanse.Target.Entities.Shared;

namespace LaDanse.Target.Entities.Settings
{
    public partial class CalendarExport : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        
        public bool ExportNew { get; set; }
        public bool ExportAbsence { get; set; }
        public string Secret { get; set; }
        
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
