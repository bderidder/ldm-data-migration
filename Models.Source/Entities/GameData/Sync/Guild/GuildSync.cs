namespace LaDanse.Source.Entities.GameData.Sync.Guild
{
    public partial class GuildSync
    {
        public string Id { get; set; }

        public string GuildId { get; set; }
        public virtual Characters.Guild Guild { get; set; }
    }
}
