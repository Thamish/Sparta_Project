using System;
using System.Collections.Generic;

namespace EF
{
    public partial class PlayerTeams
    {
        public int PlayerTeamsId { get; set; }
        public int? PlayerId { get; set; }
        public int? TeamId { get; set; }

        public virtual Players Player { get; set; }
        public virtual Teams Team { get; set; }
    }
}
