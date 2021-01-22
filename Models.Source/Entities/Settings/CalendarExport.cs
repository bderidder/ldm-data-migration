using LaDanse.Source.Entities.Identity;

namespace LaDanse.Source.Entities.Settings
{
    public partial class CalendarExport
    {
        public int Id { get; set; }
        public bool ExportNew { get; set; }
        public bool ExportAbsence { get; set; }
        public string Secret { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
