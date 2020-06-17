using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
    public partial class Positions
    {
        public override string ToString()
        {
            return $"{PositionDescription}";
        }
    }
}