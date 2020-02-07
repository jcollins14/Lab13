using System;

namespace Lab13
{
    class RoshamboApp
    {
        Player User { get; set; }
        Player Opponent { get; set; }
        private bool Loop;
        private int Wins;
        private int Losses;
        private int Draws;

        public RoshamboApp()
        {
            Draws = 0;
            Losses = 0;
            Wins = 0;
            Loop = true;
        }

        public void Play()
        {
            Console.WriteLine("Welcome to Rocky Balboa's Punch Out. Please enter your name");
            string name = Console.ReadLine().Trim();

            User = new User(name);
            if (User.Name.ToLower() == "rocky" || User.Name.ToLower() == "creed")
            {
                RoshamboAutomate();
            }

            while (Loop)
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
                    Opponent = new Rocky();
                }
                if (response == "CREED")
                {
                    Opponent = new RandomOpponent("Creed");
                }

                Console.WriteLine("You will be fighting " + Opponent.Name + ".");

                User.Action = User.GenerateRoshambo();

                Console.WriteLine("Fighter 1: " + User.Name + ". Move: " + User.Action + ".");
                Console.WriteLine("Fighter 2: " + Opponent.Name + ". Move: " + Opponent.Action + ".");

                string outcome = Clash(User, Opponent);
                if (outcome == "draw")
                {
                    Console.WriteLine("Draw! Both players threw " + User.Action + ".");
                    Draws++;
                }
                else if (outcome == "loss")
                {
                    Console.WriteLine("You Lose!");
                    Losses++;
                }
                else if (outcome == "win")
                {
                    Console.WriteLine("You Win!");
                    Wins++;
                }

                Console.WriteLine("Current Record: " + Wins + " Wins, " + Losses + " Losses, " + Draws + " Draws.");

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
                    Loop = false;
                }
                Console.Clear();
            }

            Console.WriteLine("Your final record was: " + Wins + " Wins, " + Losses + " Losses, " + Draws + " Draws.");
            Console.WriteLine("Thanks for fighting, " + User.Name + "!");
            Environment.Exit(1);
        }

        public string Clash(Player user, Player opponent)
        {
            if (user.Action == Roshambo.rock)
            {
                if (opponent.Action == Roshambo.rock)
                {
                    return "draw";
                }
                else if (opponent.Action == Roshambo.paper)
                {
                    return "loss";
                }
                else if (opponent.Action == Roshambo.scissors)
                {
                    return "win";
                }
            }
            else if (user.Action == Roshambo.paper)
            {
                if (opponent.Action == Roshambo.paper)
                {
                    return "draw";
                }
                else if (opponent.Action == Roshambo.scissors)
                { 
                    return "loss";
                }
                else if (opponent.Action == Roshambo.rock)
                {
                    return "win";
                }
            }
            else if (user.Action == Roshambo.scissors)
            {
                if (opponent.Action == Roshambo.scissors)
                {
                    return "draw";
                }
                else if (opponent.Action == Roshambo.rock)
                {
                    return "loss";
                }
                else if (opponent.Action == Roshambo.paper)
                {
                    return "win";
                }
            }
            return "error";
        }

        public void RoshamboAutomate()
        {
            Rocky rocky = new Rocky();
            RandomOpponent creed = new RandomOpponent("Creed");
            
            Console.WriteLine("How many fights would you like to simulate?");
            string response = "error";
            int fights = 0;
            while (response == "error")
            {
                response = Console.ReadLine();
                try
                {
                    fights = int.Parse(response);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please input a proper integer.");
                    response = "error";
                }
            }

            Console.WriteLine("Simulating...");

            for (int i = 0; i < fights; i++)
            {
                string result = Clash(creed, rocky);
                if (result == "draw")
                {
                    Draws++;
                }
                else if (result == "loss")
                {
                    Losses++;
                }
                else if (result == "win")
                {
                    Wins++;
                }
                creed.Action = creed.GenerateRoshambo();
            }

            Console.WriteLine("Simulation Complete.");
            Console.WriteLine("Rocky's final record vs Creed was: " + Wins + " Wins, " + Losses + " Losses, " + Draws + " Draws.");
            Console.WriteLine("Thanks for fighting!");
            Environment.Exit(1);
        }
    }
}
