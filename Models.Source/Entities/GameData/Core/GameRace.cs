namespace LaDanse.Source.Entities.GameData.Core
{
    public partial class GameRace
    {
        public GameRace()
        {
        }

        public string Id { get; set; }
        public int GameId { get; set; }
        public string FactionId { get; set; }
        public string Name { get; set; }

        public virtual GameFaction Faction { get; set; }
    }
}
