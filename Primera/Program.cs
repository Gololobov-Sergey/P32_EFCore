using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Primera.Models;

namespace Primera
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (PrimeraContext db = new())
            //{
            //    var p = db.Players
            //        .Include(p => p.Team)
            //        .Include(p => p.Position)
            //        .Include(p => p.Goals)
            //            .ThenInclude(g => g.Match)
            //                .ThenInclude(m => m.Team1)
            //        .Include(p => p.Goals)
            //            .ThenInclude(g => g.Match)
            //                .ThenInclude(m => m.Team2)
            //        .ToList();

            //    foreach (var player in p)
            //    {
            //        System.Console.WriteLine($"{player.Name} - {player.Team.Name} - {player.Position.Name}");
            //        if (player.Goals.Count == 0)
            //        {
            //            System.Console.WriteLine("\tNo goals");
            //        }
            //        else
            //        {
            //            foreach (var goal in player.Goals)
            //            {
            //                System.Console.WriteLine($"\t{goal.Match.Date} - {goal.Match.Team1.Name} - {goal.Match.Team2.Name} {goal.Minute}'");
            //            }
            //        }
            //    }
            //}

            //List<Team> teams = new();

            //using (PrimeraContext db = new())
            //{
            //    teams = db.Teams.ToList();
            //}

            //List<string?> menuItems = teams.Select(t => t.Name).ToList();
            //int c = ConsoleMenu.SelectVertical(HPosition.Left, VPosition.Top, HorizontalAlignment.Right, menuItems!);
            //Team team1 = teams[c];
            ////menuItems.RemoveAt(c);
            //c = ConsoleMenu.SelectVertical(HPosition.Left, VPosition.Top, HorizontalAlignment.Right, menuItems!);
            //Team team2 = teams[c];
            //int f = 0;


            using (PrimeraContext db = new())
            {
                string name = "Sergio Ramos";
                //SqlParameter p = new SqlParameter("name", name);
                //var t = db.Teams.FromSqlRaw($"SELECT * FROM GetTeamsFromCity('{name}')").ToList();
                
                //var t = db.GetTeamsFromCity(name).ToList();

                var t = db.Teams.FromSqlRaw($"GetTeamFromPlayer '{name}'").ToList();

                //SqlParameter p = new SqlParameter()
                //{
                //    ParameterName = "name",
                //    Value = name,
                //    SqlDbType = System.Data.SqlDbType.NVarChar,
                //    Direction = System.Data.ParameterDirection.Input
                //};

                foreach (var team in t)
                {
                    System.Console.WriteLine(team.Name + " " + team.City);
                }
            }
        }


    }
}
