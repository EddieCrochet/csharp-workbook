using System;

namespace practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("success");
        }
    }

    class Car
    {
        public double hourlyRentalRate {get; set;}

        public Car(double HourlyRentalRate)
        {
            this.hourlyRentalRate = HourlyRentalRate;
        }
    }

    class HotelRoom
    {
        public int nightlyRentalRate{get; set;}

        public HotelRoom(int NightlyRentalRate)
        {
            this.nightlyRentalRate = NightlyRentalRate;
        }
    }
}
