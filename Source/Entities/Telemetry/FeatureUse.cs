using System;
using LaDanse.Source.Entities.Identity;

namespace LaDanse.Source.Entities.Telemetry
{
    public partial class FeatureUse
    {
        public int Id { get; set; }

        public DateTime UsedOn { get; set; }
        public string Feature { get; set; }
        public string RawData { get; set; }

        public int? UsedById { get; set; }
        public virtual Account UsedBy { get; set; }
    }
}
