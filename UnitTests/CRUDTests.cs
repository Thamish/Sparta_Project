using NUnit.Framework;
using CRUDManager;
using EF;
using System.Linq;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    public class CRUDTests
    {
        private Program _crudManager = new Program();
        [SetUp]
        public void Setup()
        { 
        }

        [Test]
        public void RetrievingPosition()
        {
            int result = CRUDManager.Program.RetrievePositions().Count;
            int expected = 4;
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void AddPlayer()
        {
            int expected;
            int result;
            using (var db = new FootballContext())
            {
                expected = db.Players.Count() + 1;
                Players newplayer = new Players
                {
                    FirstName = "Test",
                    PositionId = 1,
                    LastName = "Test",
                    DateOfBirth = DateTime.Parse("1111/11/11"),
                    Nationality = "Test"
                };
                db.Players.Add(newplayer);
                db.SaveChanges();
                result = db.Players.Count();
                db.Remove(newplayer);
                db.SaveChanges();
            }
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void RemovePlayer()
        {
            int expected;
            int result;
            using (var db = new FootballContext())
            {
                
                Players newplayer = new Players
                {
                    FirstName = "Test",
                    PositionId = 1,
                    LastName = "Test",
                    DateOfBirth = DateTime.Parse("1111/11/11"),
                    Nationality = "Test"
                };
                db.Players.Add(newplayer);
                db.SaveChanges();
                expected = db.Players.Count()-1;
                db.Remove(newplayer);
                db.SaveChanges();
                result = db.Players.Count();
            }
            Assert.AreEqual(result, expected);
        }
        [Test]
        public void AddTeam()
        {
            int expected;
            int result;
            using (var db = new FootballContext())
            {
                expected = db.Teams.Count() + 1;
                Teams newTeam = new Teams
                {
                    TeamName = "Test"
                };
                db.Teams.Add(newTeam);
                db.SaveChanges();
                result = db.Teams.Count();
                db.Remove(newTeam);
                db.SaveChanges();
            }
            Assert.AreEqual(result, expected);
        }
        [Test]
        public void RemoveTeam()
        {
            int expected;
            int result;
            using (var db = new FootballContext())
            {
                ;
                Teams newTeam = new Teams
                {
                    TeamName = "Test"
                };
                db.Teams.Add(newTeam);
                db.SaveChanges();
                expected = db.Teams.Count()-1;
                db.Remove(newTeam);
                db.SaveChanges();
                result = db.Teams.Count();
            }
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void EditPlayer()
        {
            string expected;
            string result;
            Players newPlayer;
            Positions newPlayerPos;
            using (var db = new FootballContext())
            {
                expected = "Changed";
                Players newplayer = new Players
                {
                    FirstName = "Test",
                    PositionId = 1,
                    LastName = "Test",
                    DateOfBirth = DateTime.Parse("1111/11/11"),
                    Nationality = "Test"
                };
                Positions pos =
                    db.Positions.Where(o => o.PositionId == newplayer.PositionId).FirstOrDefault();
                db.Players.Add(newplayer);
                newPlayer = newplayer;
                newPlayerPos = pos;
                db.SaveChanges();
            }
            CRUDManager.Program.SavePlayer("Changed", "Test", "Test", DateTime.Parse("1111/11/11"),newPlayerPos, newPlayer,
                new List<Teams>());
            using (var db = new FootballContext())
            {
                var newplayer =
                    db.Players.Where(o => o.PlayerId == newPlayer.PlayerId).FirstOrDefault();
                result = newplayer.FirstName;
                db.Remove(newplayer);
                db.SaveChanges();
            }
            
            Assert.AreEqual(result, expected);
        }
        public void EditTeam()
        {
            string expected = "Changed";
            string result;
            Teams NewTeam;
            using (var db = new FootballContext())
            {
                Teams newTeam = new Teams
                {
                    TeamName = "Test"
                };
                db.Teams.Add(newTeam);
                NewTeam = newTeam;
                db.SaveChanges();
            }
            CRUDManager.Program.SaveTeam(NewTeam, NewTeam.TeamName, 0, 0, 0, 0, 0, 0, new List<Players>());
            using (var db = new FootballContext())
            {
                var newTeam =
                    db.Teams.Where(o => o.TeamId == NewTeam.TeamId).FirstOrDefault();
                var teamStats =
                    db.TeamStatistics.Where(o => o.TeamId == NewTeam.TeamId).FirstOrDefault();
                result = newTeam.TeamName;
                db.Remove(teamStats);
                db.Remove(newTeam);
                db.SaveChanges();
            }
            Assert.AreEqual(result, expected);
        }
    }
}