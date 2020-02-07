using System;

namespace Lab13
{
    class RoshamboApp
    {
        Player User { get; set; }
        Player Opponent { get; set; }
        private bool Loop;
        private double Wins;
        private double Losses;
        private double Draws;

        public RoshamboApp()
        {
            Loop = true;
        }

        public void Play()
        {
            Console.WriteLine("Welcome to Rocky Balboa's Punch Out. Please enter your name.");
            Console.WriteLine("(Hint: Enter \"Rocky\" or \"Creed\" for a surprise...)");
            string name = Console.ReadLine().Trim();

            //Runs the automated version if the user inputs rocky or creed as a name.
            User = new User(name);
            if (User.Name.ToLower() == "rocky" || User.Name.ToLower() == "creed")
            {
                RoshamboAutomate();
            }

            while (Loop)
            {
                //Data validation for selecting an opponent
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

                //Has the user pick an action.
                User.Action = User.GenerateRoshambo();

                Console.WriteLine("Fighter 1: " + User.Name + ". Move: " + User.Action + ".");
                Console.WriteLine("Fighter 2: " + Opponent.Name + ". Move: " + Opponent.Action + ".");

                //Calculates the outcome for the user against the opponent selected.
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

                //Data validation for loop response
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

            //Displays final record and says goodbye upon exit
            Console.WriteLine("Your final record was: " + Wins + " Wins, " + Losses + " Losses, " + Draws + " Draws.");
            Console.WriteLine("Thanks for fighting, " + User.Name + "!");
            Environment.Exit(1);
        }

        public string Clash(Player user, Player opponent)
        {
            //Measures user action vs opponent action. Returns string of result
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
            //Allows user to pit Rocky and Creed against each other.
            Rocky rocky = new Rocky();
            RandomOpponent creed = new RandomOpponent("Creed");
            
            Console.WriteLine("How many fights would you like to simulate?");
            string response = "error";
            double fights = 0;
            while (response == "error")
            {
                response = Console.ReadLine();
                try
                {
                    fights = double.Parse(response);
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

            //Exits application once simulation is complete
            Console.WriteLine("Simulation Complete.");
            Console.WriteLine("Rocky's final record vs Creed was: " + Wins + " Wins, " + Losses + " Losses, " + Draws + " Draws.");
            Console.WriteLine("Thanks for fighting!");
            Environment.Exit(1);
        }
    }
}
