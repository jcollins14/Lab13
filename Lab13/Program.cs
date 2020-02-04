using System;

namespace Lab13
{
    public enum Roshambo
    {
        rock,
        paper,
        scissors
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Player rocky = new Player("Rocky", rock);
            //Player creed = new RandoPlayer("Creed");
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
    }
}
