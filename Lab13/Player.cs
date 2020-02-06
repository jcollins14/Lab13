using System;
using System.Collections.Generic;
using System.Text;

namespace Lab13
{
    public enum Roshambo
    {
        rock,
        paper,
        scissors
    }
    abstract class Player
    {

        public string Name { get; set; }
        public Roshambo Action { get; set; }

        public Player()
        {
        }

        public abstract Roshambo GenerateRoshambo();
    }
}
