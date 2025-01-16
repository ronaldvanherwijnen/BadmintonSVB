namespace BadmintonSVB.Models
{
    public class Round
    {
        public int RoundNumber { get; set; }
        public List<Match> Matches { get; set; } = new List<Match>();
        public List<Player> BenchedPlayers { get; set; } = new List<Player>();

    }
}
