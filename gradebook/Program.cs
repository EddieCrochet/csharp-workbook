using System;
using System.Collections.Generic;

namespace gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your students names one at a time and enter ok when you are done.");

            //creates a new dictionary to store our gradebook
            Dictionary <String, int> gradeBook = new Dictionary<String, int>();
            string userInput = Console.ReadLine();

            //creates stack to store the names of students
            Stack<String> students = new Stack<String>();
            
            do
            {
                students.Push(userInput);
            }
            while(userInput != "ok");
            
            
        }
    }
}
