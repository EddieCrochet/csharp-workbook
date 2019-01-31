using System;

namespace Enum
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assume the current culture is en-US
            Console.WriteLine("Eddie, please enter the year you would like to know what day your birthday falls on");
            string bdayYr = Console.ReadLine();
            DateTime dt = new DateTime (Convert.ToInt32(bdayYr), 5, 16);
            Console.WriteLine("Eddie's birthday falls on {0} in the year {1}", dt.DayOfWeek, bdayYr);
        }
    }
}
