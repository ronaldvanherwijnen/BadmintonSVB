namespace BadmintonSVB.Models
{
    public class Match
    {
        public List<Player> Team1 { get; set; } = new List<Player>();
        public List<Player> Team2 { get; set; } = new List<Player>();
    }
}
