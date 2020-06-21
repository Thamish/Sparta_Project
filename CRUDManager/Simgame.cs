using EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUDManager
{
    public class Simgame
    {
        public Teams SelectedTeam1 { get; set; }
        public Teams SelectedTeam2 { get; set; }

        public void SetSelectedTeam1(object selectedItem)
        {
            SelectedTeam1 = (Teams)selectedItem;
        }
        public void SetSelectedTeam2(object selectedItem)
        {
            SelectedTeam2 = (Teams)selectedItem;
        }
        public static List<PlayerTeams> GetSelectedPlayers(Teams selectedTeam)
        {
            using var db = new FootballContext();
            var Playersquary =
                db.PlayerTeams.Where(o => o.TeamId == selectedTeam.TeamId).Include(o => o.Player).ToList();
            return Playersquary;
        }

        public static List<Players> GetRoster(List<PlayerTeams> players)
        {
            using var db = new FootballContext();
            List<Players> roster = new List<Players>();
            foreach (var player in players)
            {
                var playerQuery =
                db.Players.Where(o => o.PlayerId == player.PlayerId).FirstOrDefault();
                roster.Add(playerQuery);
            }
            return roster;
        }

        public static Tuple<string,Players,bool> ShotAttempt(List<Players> Squad, Teams team)
        {
            Random rnd = new Random();
            string result = "";
            bool goal = false;
            int chance = rnd.Next(0, 11);
            List<Players> players = new List<Players>();
            List<string> posfoot = new List<string>() { "Left", "Right" };
            List<string> locations = new List<string>()
            {
                "the center of the box",
                "the left of the box",
                "the right of the box"
            };
            foreach (var player in Squad)
            {
                if (player.PositionId == 3 || player.PositionId == 4)
                {
                    players.Add(player);
                }
            }
            var shooter = players[rnd.Next(players.Count)];
            var foot = posfoot[rnd.Next(posfoot.Count)];
            var location = locations[rnd.Next(locations.Count)];

            if (chance < 3)
            {
                result += "GOAL!" + "\n";
                result += $"{shooter} ({team.TeamName}) {foot} footed shot from {location} and he smashes it " +
                    $"into the back of the net!" + "\n";
                goal = true;
            }
            else if (chance == 4)
            {
                result += "GOAL!" + "\n";
                result += $"{shooter} ({team.TeamName}) shoots from far out " + "\n";
                result += "What an Amazing Shot!" + "\n";
                goal = true;
            }
            else if (chance == 5)
            {
                result += $"{shooter} ({team.TeamName}) shoots from far out " + "\n";
                result += "What a horrible shot!" + "\n";
            }
            else
            {
                result += $"{shooter} ({team.TeamName}) {foot} footed shot from {location}" + "\n";
                result += $"Misses to the {posfoot[rnd.Next(posfoot.Count)]} of the box" + "\n";
            }
            return new Tuple<string, Players,bool>(result,shooter,goal);
        }

        public static Tuple<string,string,string> Simulate(Teams team1, List<Players> team1Squad, Teams team2, List<Players> team2Squad)
        {
            Random rnd = new Random();
            int clock = 1;
            int team1goals = 0;
            int team2goals = 0;
            string Output = "";
            string Score = "";
            string Events = "";

            Output += $"The of lineup of {team1.TeamName}:" + "\n";
            foreach (var player in team1Squad)
            {
                Output += $"{player}" + "\n";
            }
            Output += "\n";
            Output += $"The of lineup of {team2.TeamName}:" + "\n";
            foreach (var player in team2Squad)
            {
                Output += $"{player}" + "\n";
            }
            Events += "FULL TIME!!!";
            Events += "\n" + "\n";

            Output += "\n";
            Output += "KICK OFF!!!";
            Output += "\n";
            while (clock <= 90)
            {
                int eventOdds = rnd.Next(2, 51);
                if (clock == 45)
                {
                    Output += $"{clock} MINUTES" + "\n";
                    Output += "HALF TIME!!!" + "\n";
                    Output += "\n";
                    clock += 1;
                }
                if (clock == 90)
                {
                    Output += $"{clock} MINUTES" + "\n";
                    Output += "FULL TIME!!!" + "\n";
                    Output += "\n";
                    clock += 1;
                }
                if (Enumerable.Range(0, 7).Contains(eventOdds))
                {
                    Output += $"{clock} MINUTES" + "\n";
                    if (eventOdds < 4)
                    {
                        var result = ShotAttempt(team1Squad, team1);
                        Output += result.Item1;
                        Output += "\n";

                        if (result.Item3 == true)
                        {
                            team1goals += 1;
                            Events += $"{result.Item2} ({team1.TeamName})   {clock}' ⚽" + "\n";
                        }
                    }
                    else
                    {
                        var result = ShotAttempt(team2Squad, team2);
                        Output += result.Item1;
                        Output += "\n";

                        if (result.Item3 == true)
                        {
                            team2goals += 1;
                            Events += $"{result.Item2} ({team2.TeamName})   {clock}' ⚽" + "\n";
                        }
                    }
                    clock += 1;
                }
                else
                {
                    clock += 1;
                }
            }
            Score = $"{team1goals} - {team2goals}";

            using (var db = new FootballContext())
            {
                var getteam1stats =
                    db.TeamStatistics.Where(o => o.TeamId == team1.TeamId).FirstOrDefault();
                var getteam2stats =
                    db.TeamStatistics.Where(o => o.TeamId == team2.TeamId).FirstOrDefault();
                if (team1goals == team2goals)
                {
                    getteam1stats.Draws += 1;
                    getteam2stats.Draws += 1;
                    getteam1stats.GoalsScored += team1goals;
                    getteam2stats.GoalsScored += team2goals;
                    getteam1stats.GoalsConceded += team2goals;
                    getteam2stats.GoalsConceded += team1goals;

                }
                else if (team1goals > team2goals)
                {
                    getteam1stats.Wins += 1;
                    getteam2stats.Losses += 1;
                    getteam1stats.GoalsScored += team1goals;
                    getteam2stats.GoalsScored += team2goals;
                    getteam1stats.GoalsConceded += team2goals;
                    getteam2stats.GoalsConceded += team1goals;
                }
                else if (team1goals < team2goals)
                {
                    getteam2stats.Wins += 1;
                    getteam1stats.Losses += 1;
                    getteam1stats.GoalsScored += team1goals;
                    getteam2stats.GoalsScored += team2goals;
                    getteam1stats.GoalsConceded += team2goals;
                    getteam2stats.GoalsConceded += team1goals;
                }
                db.SaveChanges();
            }
            return new Tuple<string, string,string>(Output, Score, Events);
        }
    }
}
