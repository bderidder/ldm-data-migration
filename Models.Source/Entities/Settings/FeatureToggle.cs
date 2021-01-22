using LaDanse.Source.Entities.Identity;

namespace LaDanse.Source.Entities.Settings
{
    public partial class FeatureToggle
    {
        public int Id { get; set; }

        public string Feature { get; set; }
        public bool Toggle { get; set; }

        public int ToggleForId { get; set; }
        public virtual Account ToggleFor { get; set; }
    }
}
