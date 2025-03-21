using Microsoft.EntityFrameworkCore;

namespace Primera
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (PrimeraContext db = new())
            {
                var p = db.Players
                    .Include(p => p.Team)
                    .Include(p => p.Position)
                    .Include(p => p.Goals)
                        .ThenInclude(g => g.Match)
                            .ThenInclude(m => m.Team1)
                    .Include(p => p.Goals)
                        .ThenInclude(g => g.Match)
                            .ThenInclude(m => m.Team2)
                    .ToList();

                foreach (var player in p)
                {
                    System.Console.WriteLine($"{player.Name} - {player.Team.Name} - {player.Position.Name}");
                    if (player.Goals.Count == 0)
                    {
                        System.Console.WriteLine("\tNo goals");
                    }
                    else
                    {
                        foreach (var goal in player.Goals)
                        {
                            System.Console.WriteLine($"\t{goal.Match.Date} - {goal.Match.Team1.Name} - {goal.Match.Team2.Name} {goal.Minute}'");
                        }
                    }
                }
            }
        }
    }
}
