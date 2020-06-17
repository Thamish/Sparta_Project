using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
    public partial class Players
    {
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
