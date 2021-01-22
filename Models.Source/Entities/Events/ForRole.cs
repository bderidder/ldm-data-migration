namespace LaDanse.Source.Entities.Events
{
    public partial class ForRole
    {
        public int Id { get; set; }

        public string Role { get; set; }

        public int SignUpId { get; set; }
        public virtual SignUp SignUp { get; set; }
    }
}
