using System;
using System.Collections.Generic;

namespace EF
{
    public partial class TeamStatistics
    {
        public int PlayerStatisticsId { get; set; }
        public int? TeamId { get; set; }
        public int? MatchesPlayed { get; set; }
        public int? Wins { get; set; }
        public int? Losses { get; set; }
        public int? Draw { get; set; }
        public int? GoalsScored { get; set; }
        public int? GoalsConceded { get; set; }

        public virtual Teams Team { get; set; }
    }
}
