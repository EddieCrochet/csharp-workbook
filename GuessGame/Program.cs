using System;
using System.IO;

namespace GuessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Eddie\Desktop\words_alpha.txt");
            //reads every english word from the file into an array

            Random rng = new Random();
            int r = rng.Next(lines.Length);
            //creates a random number and selects a word for that number from our array of words
            string compWord = lines[r];

            Console.WriteLine("I have a word. Guess in the console and I will give you hints along the way.");
            Console.WriteLine("My word I picked is {0}", compWord);
            string userGuess = Console.ReadLine();

            int compNum = Array.IndexOf(lines, compWord); //or just r
            int userNum = Array.IndexOf(lines, userGuess);
            //Console.WriteLine(userNum);

            while(compNum != userNum)
            {
                if(compNum < userNum)
                {
                    Console.WriteLine("That guess comes after my word! Try again!");
                }
                else if(userNum < compNum)
                {
                    Console.WriteLine("That guess comes before my word! Try again!");
                }
                userGuess = Console.ReadLine();
                userNum = Array.IndexOf(lines, userGuess);
            }

            if(compNum == userNum)
            {
                Console.WriteLine("Holy crap, you won.");
            }
            Console.WriteLine();





/*
            bool CheckWin()
            {
                if(userNum == compNum)
                    return true;
                else
                    return false;
            }
            

            bool won = false;
            while(!won)
            {         
                if(compNum < userNum)
                {
                    Console.WriteLine("That guess comes after my word!");
                }
                else if(userNum < compNum)
                {
                    Console.WriteLine("That guess comes before my word!");
                }
                else
                {
                    Console.WriteLine("Good Lawd! You got my word!");
                }
                won = CheckWin();
            }
            */
        }
    }
}
