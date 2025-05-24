namespace MyApp
{
    public class Room
    {
        public int Id { get; set; }
        public Dictionary<string, int> Paths { get; set; } = new();
        public string? Description { get; set; }
        public Action? Encounter { get; set; } = null;
        public bool Visited { get; set; } = false; // Track first entry

    }
}