using System;
using System.Collections.Generic;

namespace Checkpoint1
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramOne();
            ProgramTwo();
            ProgramThree();
            ProgramFour();
            ProgramFive();
        }

        static void ProgramOne()
        {
            //PROBLEM ONE

            //my integer count will store the numbers I want to display from the loop
            int count = 0;
            //typical for loop to run the numbers i need
            for (int i = 0; i < 101; i++)
            {
                //mod 3 says any number divisable by 3 with no remainder
                if (i % 3 == 0)
                {
                    //add to my count variable
                    count++;
                }
            }
            Console.WriteLine("Problem One...");
            Console.WriteLine("There are "+count+" numbers between 1 and 100 that divide by 3 with no remainder.");
            Console.WriteLine();
        }

        static void ProgramTwo()
        {

            //creating a list to store the entered numbers
            List<string> nums = new List<string>();
            string userInput = "";
            int total = 0;

            //introduces prompt
            Console.WriteLine("Problem Two...");
            Console.WriteLine("Howdy. Please enter some numbers and enter ok when you are done.");
            //loop to collect the numbers
            do
            {
                userInput = Console.ReadLine();
                //reads user input and adds to our list
                nums.Add(userInput);
            }
            while (userInput != "ok");
            //move on when the user enters "ok"

            int sum = 0;
            //this integer will be the result of added user input numbers

            foreach (string s in nums)
            //loop to convert the stored string values in the list to integers
            {
                    
                bool result = Int32.TryParse(s, out sum);
                //converts and adds to the total sum
                if (result)
                {
                    total += sum;
                    //this is where i need to get the sum to add to itself
                }
                    
            }
            
            Console.WriteLine("The total sum is " + total);
            Console.WriteLine();
            

        }

        static void ProgramThree()
        {
            //intro to the prompt
            Console.WriteLine("Program Three...");
            Console.WriteLine("Please enter a number.");
            //assigns the variable for user input and converts to and integer
            int userInput = Convert.ToInt32(Console.ReadLine());

            //loop to cycle thru numbers and set up factorial
            for (int i = userInput - 1; i >= 1; i--)
            {
                userInput = userInput * i;
            }
            Console.WriteLine("the factorial is " +userInput); 
            Console.WriteLine();
            //calculate and output
        }

        static void ProgramFour()
        {
            Console.WriteLine("Program Four...");
            //the computer stores a number between 1 and 10 in the int compChoice
            Random rng = new Random();
            int compChoice = rng.Next(1,11);
            //int for the user number later on after some conversions
            int userNum = 0;

            Console.WriteLine("I am thinking of a number between 1 and 10.");
            Console.WriteLine();
            Console.WriteLine("I will give you 4 guesses to find my number. You may begin");
            Console.WriteLine();

            //a for loop to keep track of howmany guesses/which one we are on
            for (int i = 4; i>0; i--)
            {
                Console.WriteLine("Enter a guess:");
                string userInput = Console.ReadLine();

                //converting the user input from string to int
                bool convert = Int32.TryParse(userInput, out userNum);

                if (convert)
                //if the conversion works
                {
                    if (userNum == compChoice)
                    {
                        Console.WriteLine("Darn. You got me. You won");
                        break;
                    }
                    else if (i == 1)
                    {
                        Console.WriteLine("You lose. No more guesses!");

                    }
                    else
                    {
                        Console.WriteLine("Wrong. You lose. You have {0} guesses left",i-1);
                    }
                }
                else
                //if the conversion does not work
                {
                    Console.WriteLine("Thats not a number and you lose a guess!");

                }               
            }
            Console.WriteLine();
        }

 
        public static void ProgramFive()
        {
            //intro to the program
            Console.WriteLine("Program Five...");
            Console.WriteLine();
            Console.WriteLine("Please enter a series of numbers separated by commas.");
            Console.WriteLine();

            //creates a list to store the ints in later
            List<int> userFinal = new List<int>();
            //reads what the user inputs
            string userInput = Console.ReadLine();
            //variable for a data type conversion later on
            //loop to begin conversions
//read input as string
//split string

            string[] myArray = userInput.Split(',');
            

            foreach (string s in myArray)
            {
                int options = 0;
                bool result = Int32.TryParse(s, out options);

                if (result)
                {
                    userFinal.Add(options);
                }
            }

            userFinal.Sort();
            userFinal.Reverse();

            Console.WriteLine("The largest number is {0}.",userFinal[0]);
        }
    }
}
