using System;
using LaDanse.Source.Entities.Identity;

namespace LaDanse.Source.Entities.Telemetry
{
    public partial class Feedback
    {
        public int Id { get; set; }

        public DateTime PostedOn { get; set; }
        public string Content { get; set; }

        public int PostedById { get; set; }
        public virtual Account PostedBy { get; set; }
    }
}
