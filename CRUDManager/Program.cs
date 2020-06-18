using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CRUDManager
{
    public class Program
    {
        public Teams SelectedTeam { get; set; }
        public Players SelectedPlayer { get; set; }
        public List<Teams> SelectedTeams = new List<Teams>();
        public List<Players> SelectedPlayers = new List<Players>();
        static void Main(string[] args)
        {
        }
        public static List<Teams> RetrieveTeams()
        {
            using var db = new FootballContext();
            return db.Teams.ToList();
        }
        public static List<Positions> RetrievePositions()
        {
            using var db = new FootballContext();
            return db.Positions.ToList();
        }
        public static List<Players> RetrievePlayers()
        {
            using var db = new FootballContext();
            return db.Players.ToList();
        }
        public static List<Teams> GetSelectedTeams(Players selectedPlayer)
        {
            List<Teams> output = new List<Teams>();
            using var db = new FootballContext();
            var teamsquary =
                db.PlayerTeams.Where(o => o.PlayerId == selectedPlayer.PlayerId).Include(o => o.Team);
            foreach (var team in teamsquary)
            {
                output.Add(team.Team);
            }
            return output;
        }
        public static void AddTeam(Teams team, Players selectedPlayer)
        {
            using var db = new FootballContext();
            PlayerTeams newEntry = new PlayerTeams
            {
                PlayerId = selectedPlayer.PlayerId,
                TeamId = team.TeamId
            };
            db.PlayerTeams.Add(newEntry);
            db.SaveChanges();
        }
        public static void RemoveTeam(Teams team, Players selectedPlayer)
        {
            using var db = new FootballContext();
            var entry =
                db.PlayerTeams.Where(o => o.PlayerId == selectedPlayer.PlayerId && o.TeamId == team.TeamId).First();
            db.PlayerTeams.Remove(entry);
            db.SaveChanges();
        }
        public void SetSelectedTeam(object selectedItem)
        {
            SelectedTeam = (Teams)selectedItem;
        }
        public void SetSelectedPlayer(object selectedItem)
        {
            SelectedPlayer = (Players)selectedItem;
        }
        public static void SubmitPlayer(string firstName, string lastName, string nationality, DateTime dob,
            List<Teams> selectedTeams, Positions pos)
        {
            using var db = new FootballContext();
            Players newPlayer = new Players
            {
                FirstName = firstName,
                LastName = lastName,
                Nationality = nationality,
                DateOfBirth = dob,
                PositionId = pos.PositionId
            };
            db.Players.Add(newPlayer);
            db.SaveChanges();
            foreach (var team in selectedTeams)
            {
                PlayerTeams newEntry = new PlayerTeams
                {
                    PlayerId = newPlayer.PlayerId,
                    TeamId = team.TeamId
                };
                db.PlayerTeams.Add(newEntry);
            };
            db.SaveChanges();
        }

        public static void SavePlayer(string firstName, string lastName, string nationality, DateTime dob,
            Positions pos, Players selectedPlayer)
        {
            using var db = new FootballContext();
            var findPlayer =
                db.Players.Where(o => o.PlayerId == selectedPlayer.PlayerId).First();
            findPlayer.FirstName = firstName;
            findPlayer.LastName = lastName;
            findPlayer.Nationality = nationality;
            findPlayer.DateOfBirth = dob;
            findPlayer.PositionId = pos.PositionId;
            db.SaveChanges();
        }

        public static void SubmitTeam(string teamName, List<Players> selectedPlayers)
        {
            using var db = new FootballContext();
            Teams newTeam = new Teams
            {
                TeamName = teamName
            };
            db.Teams.Add(newTeam);
            db.SaveChanges();
            foreach (var selectedplayer in selectedPlayers)
            {
                PlayerTeams newEntry = new PlayerTeams
                {
                    TeamId = newTeam.TeamId,
                    PlayerId = selectedplayer.PlayerId
                };
                db.PlayerTeams.Add(newEntry);
            }
            TeamStatistics newStatistics = new TeamStatistics
            {
                TeamId = newTeam.TeamId,
                MatchesPlayed = 0,
                Wins = 0,
                Draws = 0,
                Losses = 0,
                GoalsScored = 0,
                GoalsConceded = 0
            };
            db.SaveChanges();
        }

        public static void RemovePlayer(Players selectedPlayer)
        {
            using var db = new FootballContext();
            var getPlayerTeams =
                db.PlayerTeams.Where(o => o.PlayerId == selectedPlayer.PlayerId);
            foreach (var playerteam in getPlayerTeams)
            {
                db.PlayerTeams.Remove(playerteam);
            }
            db.Players.Remove(selectedPlayer);
            db.SaveChanges();
        }
        public static void RemoveTeam(Teams selectedTeam)
        {
            using var db = new FootballContext();
            var getPlayerTeams =
                db.PlayerTeams.Where(o => o.TeamId == selectedTeam.TeamId);
            foreach (var playerteam in getPlayerTeams)
            {
                db.PlayerTeams.Remove(playerteam);
            }
            db.Teams.Remove(selectedTeam);
            db.SaveChanges();
        }

        public static List<Players> FilterPlayers(string filter, Positions pos)
        {
            using var db = new FootballContext();
            if (filter == "")
            {
                if ((pos == null || pos.PositionId == 6))
                {
                    return db.Players.ToList<Players>();
                }
                else
                {
                    var quary =
                    db.Players.Where(o => o.PositionId == pos.PositionId)
                    .OrderBy(o => o.FirstName);
                    return quary.ToList<Players>(); ;
                }
            }
            else if ((pos == null || pos.PositionId == 6))
            {   
                var quary =
                    db.Players.Where(o => o.FirstName.Contains(filter))
                    .OrderBy(o => o.FirstName);
                return quary.ToList<Players>();
            }
            else
            {
                var quary =
                    db.Players.Where(o => o.FirstName.Contains(filter) && o.PositionId == pos.PositionId)
                    .OrderBy(o => o.FirstName);
                return quary.ToList<Players>();
            }
        }

        public static List<Teams> FilterTeams(string filter)
        {
            using var db = new FootballContext();
            if (filter == "")
            {
                return null;
            }
            else
            {
                var quary =
                    db.Teams.Where(o => o.TeamName.Contains(filter))
                    .OrderBy(o => o.TeamName);
                return quary.ToList<Teams>();
            }
        }
    }
}
