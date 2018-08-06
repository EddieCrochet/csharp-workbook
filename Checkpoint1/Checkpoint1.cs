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
            Console.WriteLine("the facorial is " +userInput); 
            //calculate and output
        }

        static void ProgramFour()
        {
            
        }
    }
}
