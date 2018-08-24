using System;

namespace practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sunday is "+(int)DaysOfTheWeek.Sunday);

            DaysOfTheWeek today = DaysOfTheWeek.Wednesday;
            DaysOfTheWeek tomorrow = today+1;
            Console.WriteLine("if today is {0}, then tomorrow will be {1}", today, getNextDay(today));
            Console.WriteLine("Tomorrow is "+ tomorrow);
        }

        public static DaysOfTheWeek getNextDay(DaysOfTheWeek day)
        {
            if(day == DaysOfTheWeek.Saturday)
            {
                return DaysOfTheWeek.Sunday;
            }
            else
            {
            return (DaysOfTheWeek)(((int)day+1)%7);
            }
        }
        public static bool isWeekend(DaysOfTheWeek day)
        {
            if(day == DaysOfTheWeek.Sunday || day == DaysOfTheWeek.Saturday)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public enum DaysOfTheWeek
    {
        Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
    }
}
