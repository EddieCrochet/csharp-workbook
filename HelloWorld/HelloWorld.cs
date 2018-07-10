using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Eddie!");
            string name = "";
		int age = 0;
		int year = 0;
		
		Console.WriteLine("Please enter your name: ");
		name = Console.ReadLine();
		Console.WriteLine("Please enter your age: ");
		age = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Please enter the year: ");
		year = Convert.ToInt32(Console.ReadLine());
		
		Console.WriteLine("Hello! My name is {0} and I am {1} years old. I was born in {2}.", name, age, year-age);
        }
    }
}
