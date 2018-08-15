using System;
using System.Collections;
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
            string userInput = "";
            int average = 0;

            //creates list so we can find the average of the student grade
            List<int> findAve = new List<int>();

            //creates stack to store the names of students
            Stack<String> students = new Stack<String>();

            userInput = Console.ReadLine();
            
            while (userInput != "ok")
            {
                //assign userInput to read the line store as string and push to our stack of students
                students.Push(userInput);
                userInput = Console.ReadLine();
            }

            //loop to enter grades and find the averages
            foreach(string stu in students)
            {
                Console.WriteLine("Now please enter grades for " +stu+ " separated by commas and press enter when you are done");

                string grades = Console.ReadLine();
                string[] gradeArray = grades.Split(',');

                foreach (string s in gradeArray)
                {
                    int g = 0;
                    bool result = Int32.TryParse(s, out g);

                    if (result)
                    {
                        findAve.Add(g);
                    }
                }

                int total = 0;

                foreach(var itm in findAve)
                {
                    total += itm;
                }

                average = total / findAve.Count;

                gradeBook.Add(stu, average);

                findAve.Clear();
            }

            foreach (KeyValuePair<string, int> grade in gradeBook)
            {
                Console.WriteLine("Student {0} has an average of {1}", grade.Key, grade.Value);
            }
        }
    }
}
