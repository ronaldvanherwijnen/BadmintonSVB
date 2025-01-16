namespace BadmintonSVB.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BenchCount { get; set; } = 0; // Aantal keer dat de speler op de bank zat
        public int MostRecentBenchRound { get; set; } = 0;
        public HashSet<int> PlayedWith { get; set; } = new HashSet<int>();
        public HashSet<int> PlayedAgainst { get; set; } = new HashSet<int>();
    }
}
