using System;
using System.Collections.Generic;
using System.Text;

namespace Lab13
{
    class User : Player
    {
        public User(string name)
        {
            this.Name = name;
        }

        public override Roshambo GenerateRoshambo()
        {
            string answer = "error";
            while (answer == "error")
            {
                answer = ChooseRPS();
            }

            if (answer == "rock")
            {
                return Roshambo.rock;
            }
            else if (answer == "paper")
            {
                return Roshambo.paper;
            }
            else
            {
                return Roshambo.scissors;
            }
        }

        public static string ChooseRPS()
        {
            string input;
            Console.WriteLine("Which action would you like to take? Rock, Paper, or Scissors?");
            input = Console.ReadLine().ToLower().Trim();

            if (input == "rock" || input == "paper" || input == "scissors")
            {
                return input;
            }
            else
            {
                Console.WriteLine("Please select again.");
                return "error";
            }
        }
        public override string ToString()
        {
            return "My name is " + base.Name + " and my move is " + base.Action + ".";
        }
    }
}
