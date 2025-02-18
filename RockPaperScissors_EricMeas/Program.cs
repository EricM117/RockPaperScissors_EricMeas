using System;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace RockPaperScissors_EricMeas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RockPaperScissors();
        }

        static void RockPaperScissors()
        {
            string? roundStart = "Choose your move: Rock, Paper, Scissors, Lizard, or Spock.";
            string[] choicesList = { "rock", "paper", "scissors", "lizard", "spock" };

            /// Dictionary used to store a string and their values, the values will be compared to the string
            Dictionary<string, List<string>> winConditions = new Dictionary<string, List<string>>()
            {
                { "rock", new List<string> { "scissors", "lizard" } },
                { "paper", new List<string> { "rock", "spock" } },
                { "scissors", new List<string> { "paper", "lizard" } },
                { "lizard", new List<string> { "paper", "spock" } },
                { "spock", new List<string> { "scissors", "rock" } }
            };

            bool isPlaying = true;
            int playerScore = 0;
            int opponentScore = 0;
            while (isPlaying)
            {
                /// Takes in a string input and stores it into userInput, also makes it case insensitive
                Console.WriteLine("\n" + "First to five wins." + "\n" + roundStart);
                string? userInput = Console.ReadLine()?.Trim().ToLower();

                /// Checks if the input is an available option in the dictionary
                if (!Array.Exists(choicesList, choice => choice.Equals(userInput, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Invalid choice! Please select a valid action.");
                    continue;
                }

                Random rand = new Random();
                string opponentChoice = choicesList[rand.Next(choicesList.Length)];

                Console.WriteLine($"Opponent chose: {opponentChoice}");

                /// Code below determines winner
                if (userInput.Equals(opponentChoice, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("It's a tie!");
                }
                else if (winConditions[userInput].Contains(opponentChoice))
                {
                    Console.WriteLine("You win this round!");
                    playerScore++;
                }
                else if (winConditions[opponentChoice].Contains(userInput))
                {
                    Console.WriteLine("Opponent wins this round!");
                    opponentScore++;
                }

                Console.WriteLine($"Score - Player: {playerScore}, Opponent: {opponentScore}");

                if (playerScore == 5 || opponentScore == 5)
                {
                    if (playerScore == 5)
                    {
                        Console.WriteLine("You Win!");
                        isPlaying = false;
                    }

                    else if (opponentScore == 5)
                    {
                        Console.WriteLine("You Lose!");
                        isPlaying = false;
                    }
                }
            }
        }
    }
}
