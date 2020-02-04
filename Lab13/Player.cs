using System;
using System.Collections.Generic;
using System.Text;

namespace Lab13
{
    class Player
    {
        private string name;
        private Roshambo action;

        public string Name;
        public Roshambo Action;

        public Player(string name, Roshambo action)
        {
            this.Name = name;
            this.Action = action;
        }

        protected virtual Roshambo generateRoshambo()
        {
            Roshambo move = Roshambo.rock;
            return move;
        }
    }
}
