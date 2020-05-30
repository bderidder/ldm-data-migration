using LaDanse.Source.Entities.Identity;

namespace LaDanse.Source.Entities.Settings
{
    public partial class Setting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
