namespace BoardGameAPI.Entities
{
    public class BoardGame
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public string CoreMechanic { get; set; } = string.Empty;
        public int MinPlayerCount { get; set; } = 1;
        public int MaxPlayerCount { get; set; } = 1;
    }
}
