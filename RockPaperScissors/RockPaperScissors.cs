using System;

namespace RockPaperScissors
{
    class Program
    {
        public static int pScore = 0;
        public static int cScore = 0;

        public static void Main()
        {
            //the user is allowed a choice of hand to play with
            string pHand = System.String.Empty;
            try
            {
                Console.WriteLine("Do you choose Rock, Paper, or Scissors?");
                pHand = Console.ReadLine().ToLower();
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                if (pHand != "rock" && pHand != "paper" && pHand != "scissors")
                {
                    Console.WriteLine("YOU HAVE MADE NO SELECTION!!!!");
                }
                else
                {
                Console.WriteLine("You have chosen " +pHand);
                }
            }
//try-catch-and exception to not allow the user to input any thing that is not rock or paper or scissors

            string cHand = System.String.Empty;
//generate random number and assign to an integer
            Random rng = new Random();
            int ran = rng.Next(0, 2);

//assign random selected number to rock, paper, or scissors and call that the computer's hand
            if (ran == 0)   
            {
                cHand = "rock";
            }else if (ran == 1)
            {
                cHand = "paper";
            }else
            {
                cHand = "scissors";
            }

//lets you know the computer choice
//outputs the winning results
            Console.WriteLine("Computer has chosen "+cHand); 
            CompareHands(pHand, cHand);
            Console.WriteLine("You: " +pScore);
            Console.WriteLine("Me: " +cScore);

            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
            Replay();
            
        }
        

        public static void CompareHands(string pHand, string cHand)
        //create function to actually evaluate the winner
        {
            if (pHand == cHand)
            {
                Console.WriteLine("It's a tie!");
            }

            else if (pHand == "rock" && cHand == "scissors")
            {
                pScore++;
                Console.WriteLine("You win! computers will rise again");
            }
            
            else if (pHand == "paper" && cHand == "rock")
            {
                pScore++;
                Console.WriteLine("You win! computers will rise again");
            }

            else if (pHand == "scissors" && cHand == "paper")
            {
                pScore++;
                Console.WriteLine("You win! computers will rise again");
            }
            else
            {
                cScore++;
                Console.WriteLine("I beat a human!!!");
            }
            
        }

        public static void Replay()
        {
            Console.WriteLine("Do you want to play again? [y/n]");
            string replay = Console.ReadLine().ToLower();
            if (replay == "y")
            {
                Main();
            }
            else 
            {
                Console.WriteLine("Thanks for playing!!");
            }
        }
    }
}
