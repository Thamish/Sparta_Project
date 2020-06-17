using System;
using System.Collections.Generic;
using System.Linq;
using EF;

namespace CRUDManager
{
    public class Program
    {
        public Teams SelectedTeam { get; set; }
        public List<Teams> SelectedTeams = new List<Teams>();
        static void Main(string[] args)
        {
        }

        public static List<Teams> RetrieveTeams()
        {
            using var db = new FootballContext();
            return db.Teams.ToList();
        }

        public void SetSelectedTeam(object selectedItem)
        {
            SelectedTeam = (Teams)selectedItem;
        }
    }
}
