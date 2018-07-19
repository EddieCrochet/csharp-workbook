using System;

namespace RockPaperScissors
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter hand 1:");
            string hand1 = Console.ReadLine().ToLower();

            Random rng = new Random();
            rng.Next(0, 2);

            Console.WriteLine("Enter hand 2:");
            string hand2 = Console.ReadLine().ToLower();
            Console.WriteLine(CompareHands(hand1, hand2));

            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }
        
        public static string CompareHands(string hand1, string hand2)
        {
            if (hand1 == hand2)
        {
        return "It's a tie!";
        }

        if (hand1 == "rock")
        {
        if (hand2 == "scissors")
        {
            return "Hand one wins!";
        }
        // If we reach here, player 2 must have dealt paper
        return "Hand two wins!";
        }

        if (hand1 == "paper")
        {
        if (hand2 == "rock")
        {
            return "hand one wins!";
        }
        //if we reach here, player 2 must have dealt scissors
            return "Hand two wins!";
        }

        if (hand1 == "scissors")
        {
        if (hand2 == "paper")
        {
            return "Hand one wins!";
        } 
        //If we get here we know that player two has dealt rock
            return "Hand two wins!";
        }
            return hand1 + ' ' + hand2;
        }
    }
}
