using System;
using System.Collections.Generic;
using System.Text;

namespace Lab13
{
    class Rocky : Player
    {
        public Rocky()
        {
            this.Name = "Rocky";
            this.Action = Roshambo.rock;
        }

        public override Roshambo GenerateRoshambo()
        {
            return Roshambo.rock;
        }
        public override string ToString()
        {
            return "My name is " + base.Name + " and my move is " + base.Action + ".";
        }
    }
}
