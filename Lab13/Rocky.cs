using System;
using System.Collections.Generic;
using System.Text;

namespace Lab13
{
    class Rocky : Player
    {
        public Rocky(string name)
        {
            this.Name = name;
            this.Action = Roshambo.rock;
        }

        protected override Roshambo generateRoshambo()
        {
            return Roshambo.rock;
        }
    }
}
