using System;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Practice 1

        int dogs = 0;
        int cats = 0;

           Console.WriteLine("How many dogs are in your life?");
           dogs = Convert.ToInt32(Console.ReadLine());
           Console.WriteLine("How many cats are in your life?");
           cats = Convert.ToInt32(Console.ReadLine());
           Console.WriteLine("Great! Sounds like you have {0} cats and dogs in your life!", dogs+cats);

           //Practice 2

        float yards = 0;

        Console.WriteLine("How many yards would you like to convert to inches?");
        yards = Convert.ToSingle(Console.ReadLine());
        Console.WriteLine("That comes out to {0} inches!!!", yards*36);

        //Practice 3:

        bool people = true;

        //Practice 4:

        bool f = false;
        
        //Practice 5:
        
        decimal num = 3.14986245389008642357M;  

        //Practice 6:

        Console.WriteLine("The product of our num variable mulitplied by itself is {0}", num*num);

        //Practice 7:

        string firstName = "Eddie";
        string lastName = "Crochet";
        byte age = 24;
        string job = "Sandwiches";
        string favoriteBand = "Rise Against";
        string favoriteSportsTeam = "Oilers";

        //Practice 8:

        Console.WriteLine("Hello, {0}{1}! You are {2} years old! Your job is {3}, favorite band is {4} and you don't like sports but you picked the {5}!",firstName, lastName, age, job, favoriteBand, favoriteSportsTeam);

        //Practice 9:

        Console.WriteLine(Convert.ToInt32(num));  

        //Practice 10:

       int a = 100;
       int b = 10;

       Console.WriteLine(a+b);
       Console.WriteLine(a*b);
       Console.WriteLine(a-b);
       Console.WriteLine(a/b);
              }
    }
}
