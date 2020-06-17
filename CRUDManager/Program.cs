using System;
using System.Collections.Generic;
using System.Linq;
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
        public void AddTeam(Teams team, Players selectedPlayer)
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
        public void RemoveTeam(Teams team, Players selectedPlayer)
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
        public void Submit(string firstName, string lastName, string nationality, string dob,
            List<Teams> selectedTeams, Positions pos)
        {
            using var db = new FootballContext();
            Players newPlayer = new Players
            {
                FirstName = firstName,
                LastName = lastName,
                Nationality = nationality,
                DateOfBirth = DateTime.Parse(dob),
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
}
}
