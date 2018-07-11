using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Eddie!");
			//this line simply tells me hello!
            string name = "";
			//defining a string called name with no value
		int age = 0;
		//defining an integer called age with a starting value of 0
		int year = 0;
		//defining a value called year with a starting value of 0
		
		Console.WriteLine("Please enter your name: ");
		//a line is printed in our console with the previous text

		name = Console.ReadLine();
		//the user is able to type and enter input to answer the question
		//the program reads the input and assigns it to the value for our name integer

		Console.WriteLine("Please enter your age: ");
		//a line is printed in our console with the previous text

		age = Convert.ToInt32(Console.ReadLine());
		//the user is able to type and enter input to answer the question
		//this method will convert what the user has typed into an 32 bit signed integer

		Console.WriteLine("Please enter the year: ");
		//a line is printed in our console with the previous text

		year = Convert.ToInt32(Console.ReadLine());
		//the user is able to type and enter input to answer the question
		//this method will convert what the user has typed into an 32 bit signed integer
		
		Console.WriteLine("Hello! My name is {0} and I am {1} years old. I was born in {2}.", name, age, year-age);
		//writes the intro line with all the user's info.
		//This is also where the math is done... the last value out put for the year born is done by subtracting the age from the current year
        }
    }
}
