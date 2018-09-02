using System;
using System.IO;

namespace practice
{
    class Program
    {
        static void Main(string[] args)
        {           
            string myFile = @"C:\Users\Eddie\Desktop\myFile.txt";
            //code to create a text file
            using(StreamWriter sw = File.CreateText(myFile))
            {
                sw.WriteLine("New file created: {0}", DateTime.Now.ToString());
                sw.WriteLine("Author: Eddie Crochet");
                sw.WriteLine("and whatever the hell else i want to say");
            }

            using(StreamReader sr = File.OpenText(myFile))
            //prints out the created file into the console in a controlled manner
            //but only prints before the edit
            {
                string line;

                while((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            Console.WriteLine();

            string changeText = File.ReadAllText(@"C:\Users\Eddie\Desktop\myFile.txt");
            //makes a string named changeText to store my data from myFile
            //here we edit two lines of text within our created file
            changeText = changeText.Replace("Eddie Crochet", "Edward Laurence Crochet");
            changeText = changeText.Replace("hell", "heck");
            File.WriteAllText(@"C:\Users\Eddie\Desktop\myFile.txt", changeText);

            using(StreamReader sr2 = File.OpenText(myFile))
            //reprint to the console the created file - now complete with edits
            {
                string line;

                while((line = sr2.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            if(File.Exists(myFile))
            //deletes the myFile if it exists
            {
                try
                {
                    File.Delete(myFile);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
