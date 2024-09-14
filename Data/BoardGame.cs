namespace BoardGameAPI.Data
{
    public class BoardGame
    {
        public int Id { get; set; }
        public required string Name { get; set; } = String.Empty;
        public string Publisher { get; set; } = String.Empty ;
        public string CoreMechanic { get; set; } = String.Empty;
        public int MinPlayerCount { get; set; } = 1;
        public int MaxPlayerCount { get; set;} = 1;
    }
}
