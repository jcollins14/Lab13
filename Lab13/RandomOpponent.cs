using System;
using System.Collections.Generic;
using System.Text;

namespace Lab13
{
    class RandomOpponent : Player
    {
        public RandomOpponent(string name)
        {
            this.Name = name;
            this.Action = GenerateRoshambo();
        }

        public override Roshambo GenerateRoshambo()
        {
            Random rng = new Random();
            int index = rng.Next(0, 3);
            Roshambo output = (Roshambo)index;
            return output;
        }

        public override string ToString()
        {
            return "My name is " + base.Name + " and my move is " + base.Action + ".";
        }
    }
}
