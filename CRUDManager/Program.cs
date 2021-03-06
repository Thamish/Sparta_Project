﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
        public static List<PlayerTeams> GetSelectedPlayers(Teams selectedTeam)
        {
            using var db = new FootballContext();
            var Playersquary =
                db.PlayerTeams.Where(o => o.TeamId == selectedTeam.TeamId).Include(o=>o.Player).ToList();
            return Playersquary;
        }

        public static Players GetPlayer(PlayerTeams player)
        {
            using var db = new FootballContext();
            var playerQuery =
                db.Players.Where(o => o.PlayerId == player.PlayerId).FirstOrDefault();
            return playerQuery;
        }

        public static int GetTeamSize(Teams team)
        {
            using var db = new FootballContext();
            var Numplayers =
                db.PlayerTeams.Where(o => o.TeamId == team.TeamId).Count();
            return Numplayers;
        }

        public static TeamStatistics GetTeamStatistics(Teams team)
        {
            using var db = new FootballContext();
            var stats =
                db.TeamStatistics.Where(o => o.TeamId == team.TeamId).FirstOrDefault();
            return stats;
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
            }
            db.SaveChanges();
        }
        

        public static void SavePlayer(string firstName, string lastName, string nationality, DateTime dob,
            Positions pos, Players selectedPlayer,List<Teams> teams)
        {
            using var db = new FootballContext();
            var findPlayer =
                db.Players.Where(o => o.PlayerId == selectedPlayer.PlayerId).First();
            findPlayer.FirstName = firstName;
            findPlayer.LastName = lastName;
            findPlayer.Nationality = nationality;
            findPlayer.DateOfBirth = dob;
            findPlayer.PositionId = pos.PositionId;
            var removeEntries =
                db.PlayerTeams.Where(o => o.PlayerId == selectedPlayer.PlayerId);
            foreach (var rEntry in removeEntries)
            {
                db.PlayerTeams.Remove(rEntry);
            }
            foreach (var team in teams)
            {
                PlayerTeams newEntry = new PlayerTeams
                {
                    PlayerId = selectedPlayer.PlayerId,
                    TeamId = team.TeamId
                };
                db.PlayerTeams.Add(newEntry);
            }
            db.SaveChanges();
        }

        public static void SaveTeam(Teams team, string teamName, int matchesPlayed, int wins, int draws, int losses, int goalsScored,
            int goalsConceded, List<Players> players)
        {
            using var db = new FootballContext();
            var findTeam =
                db.Teams.Where(o => o.TeamId == team.TeamId).FirstOrDefault();
            var findstats =
                db.TeamStatistics.Where(o => o.TeamId == team.TeamId).FirstOrDefault();
            findTeam.TeamName = teamName;
            findstats.MatchesPlayed = matchesPlayed;
            findstats.Wins = wins;
            findstats.Draws = draws;
            findstats.Losses = losses;
            findstats.GoalsScored = goalsScored;
            findstats.GoalsConceded = goalsConceded;
            var removeEntries =
                db.PlayerTeams.Where(o => o.TeamId == team.TeamId);
            foreach (var rEntry in removeEntries)
            {
                db.PlayerTeams.Remove(rEntry);
            }
            foreach (var player in players)
            {
                PlayerTeams newEntry = new PlayerTeams
                {
                    PlayerId = player.PlayerId,
                    TeamId = team.TeamId
                };
                db.PlayerTeams.Add(newEntry);
            }
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
            db.TeamStatistics.Add(newStatistics);
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
            var getTeamstats =
                db.TeamStatistics.Where(o => o.TeamId == selectedTeam.TeamId).FirstOrDefault();
            db.TeamStatistics.Remove(getTeamstats);
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
