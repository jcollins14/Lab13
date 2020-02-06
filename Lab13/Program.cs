using System;

namespace Lab13
{

    class Program
    {
        static void Main()
        {
            bool loop = true;
            int wins = 0;
            int losses = 0;
            int draws = 0;
            Rocky rocky = new Rocky();
            RandomOpponent creed = new RandomOpponent("Creed");
            User opponent = new User("opponent");

            Console.WriteLine("Welcome to Rocky Balboa's Punch Out. Please enter your name");
            string name = Console.ReadLine().Trim();

            User user = new User(name);

            while (loop)
            {
                Console.WriteLine("Who would you like to fight? Rocky or Creed?");
                string response = "error";
                while (response == "error")
                {
                    response = Console.ReadLine().Trim().ToUpper();
                    if (response != "ROCKY" && response != "CREED")
                    {
                        Console.WriteLine("Please select Rocky or Creed.");
                        response = "error";
                    }
                }

                if (response == "ROCKY")
                {
                    opponent.Name = rocky.Name;
                    opponent.Action = rocky.GenerateRoshambo();
                }
                if (response == "CREED")
                {
                    opponent.Name = creed.Name;
                    opponent.Action = creed.GenerateRoshambo();
                }

                Console.WriteLine("You will be fighting " + opponent.Name + ".");

                user.Action = user.GenerateRoshambo();

                Console.WriteLine("Fighter 1: " + user.Name +". Move: " + user.Action + ".");
                Console.WriteLine("Fighter 2: " + opponent.Name + ". Move: " + opponent.Action +".");

                if (user.Action == Roshambo.rock)
                {
                    if (opponent.Action == Roshambo.rock)
                    {
                        Console.WriteLine("Draw! Both players threw " + user.Action + ".");
                        draws++;
                    }
                    else if (opponent.Action == Roshambo.paper)
                    {
                        Console.WriteLine("You Lose!");
                        losses++;
                    }
                    else if (opponent.Action == Roshambo.scissors)
                    {
                        Console.WriteLine("You Win!");
                        wins++;
                    }
                }
                if (user.Action == Roshambo.paper)
                {
                    if (opponent.Action == Roshambo.paper)
                    {
                        Console.WriteLine("Draw! Both players threw " +user.Action + ".");
                        draws++;
                    }
                    else if (opponent.Action == Roshambo.scissors)
                    {
                        Console.WriteLine("You Lose!");
                        losses++;
                    }
                    else if (opponent.Action == Roshambo.rock)
                    {
                        Console.WriteLine("You Win!");
                        wins++;
                    }
                }
                if (user.Action == Roshambo.scissors)
                {
                    if (opponent.Action == Roshambo.scissors)
                    {
                        Console.WriteLine("Draw! Both players threw " + user.Action + ".");
                        draws++;
                    }
                    else if (opponent.Action == Roshambo.rock)
                    {
                        Console.WriteLine("You Lose!");
                        losses++;
                    }
                    else if (opponent.Action == Roshambo.paper)
                    {
                        Console.WriteLine("You Win!");
                        wins++;
                    }
                }

                Console.WriteLine("Current Record: " + wins + " Wins, " + losses + " Losses, " + draws + " Draws.");

                Console.WriteLine("Would you like to fight again? (yes/no)");

                response = "error";
                while (response == "error")
                {
                    response = Console.ReadLine().Trim().ToUpper();
                    if (response != "YES" && response != "NO")
                    {
                        Console.WriteLine("Please select yes or no.");
                        response = "error";
                    }
                }

                if (response == "NO")
                {
                    loop = false;
                }
                Console.Clear();
            }

            Console.WriteLine("Your final record was: " + wins + " Wins, " + losses + " Losses, " + draws + " Draws.");
            Console.WriteLine("Thanks for fighting, " + user.Name + "!");
            Environment.Exit(1);
        }
    }
}
