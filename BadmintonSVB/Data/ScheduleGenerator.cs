using BadmintonSVB.Models;

namespace BadmintonSVB.Data
{
    public class ScheduleGenerator
    {
        public GameSchedule GenerateSchedule(List<Player> players, int totalRounds, int courts)
        {
            var schedule = new GameSchedule();
            int playersPerMatch = 4;

            for (int roundNumber = 1; roundNumber <= totalRounds; roundNumber++)
            {
                var round = new Round { RoundNumber = roundNumber };
              
                var shuffledPlayers = players.OrderBy(_ => Guid.NewGuid()).ToList(); 
                var sortedPlayers = shuffledPlayers.OrderByDescending(p => p.BenchCount).ThenByDescending(p => p.MostRecentBenchRound).ToList();

                int matchesPerRound = Math.Min(courts, sortedPlayers.Count / playersPerMatch);

                for (int i = 0; i < matchesPerRound; i++)
                {
                    if (sortedPlayers.Count >= playersPerMatch)
                    {
                        var match = new Match
                        {
                            Team1 = sortedPlayers.Take(2).ToList(),
                            Team2 = sortedPlayers.Skip(2).Take(2).ToList()
                        };

                        round.Matches.Add(match);

                        sortedPlayers.RemoveRange(0, playersPerMatch);
                    }
                }

                // Overgebleven spelers zijn op de bank
                foreach (var player in sortedPlayers)
                {
                    player.BenchCount++; 
                    player.MostRecentBenchRound = roundNumber;
                }

                round.BenchedPlayers = sortedPlayers;
                schedule.Rounds.Add(round);
            }

            return schedule;
        }
    }
}
