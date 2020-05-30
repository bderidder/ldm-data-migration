using LaDanse.Source.Entities.Identity;

namespace LaDanse.Source.Entities.Events
{
    public partial class SignUp
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
