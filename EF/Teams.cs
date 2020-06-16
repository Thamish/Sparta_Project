using System;
using System.Collections.Generic;

namespace EF
{
    public partial class Teams
    {
        public Teams()
        {
            PlayerTeams = new HashSet<PlayerTeams>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; }

        public virtual ICollection<PlayerTeams> PlayerTeams { get; set; }
    }
}
