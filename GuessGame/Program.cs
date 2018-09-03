using System;
using System.IO;

namespace GuessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Eddie\Desktop\words_alpha.txt");
            //reads all our lines from the files into an array

            Random rng = new Random();
            int r = rng.Next(lines.Length);
            //creates a random number and selects a word for that number from our array of words
            string compWord = lines[r];

            Console.WriteLine("I have a word. Guess in the console and I will give you hints along the way.");
            Console.WriteLine("My word I picked is {0}", compWord);
            string userGuess = Console.ReadLine();

            int compNum = Array.IndexOf(lines, compWord);
            int userNum = Array.IndexOf(lines, userGuess);
           //Console.WriteLine(compNum);

            while(compNum != userNum)
            {
                string userGuess2 = Console.ReadLine();
                if(compNum < userNum)
                {
                    Console.WriteLine("That guess comes after my word!");
                }
                else if(userNum < compNum)
                {
                    Console.WriteLine("That guess comes before my word!");
                }
            }


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
