using System;
using System.Collections.Generic;

namespace EF
{
    public partial class Players
    {
        public Players()
        {
            PlayerTeams = new HashSet<PlayerTeams>();
        }

        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? PositionId { get; set; }
        public string Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public virtual Positions Position { get; set; }
        public virtual ICollection<PlayerTeams> PlayerTeams { get; set; }
    }
}
