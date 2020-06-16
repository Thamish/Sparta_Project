using System;
using System.Collections.Generic;

namespace EF
{
    public partial class Positions
    {
        public Positions()
        {
            Players = new HashSet<Players>();
        }

        public int PositionId { get; set; }
        public string PositionDescription { get; set; }

        public virtual ICollection<Players> Players { get; set; }
    }
}
