using System;
using System.Collections.Generic;

namespace practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Car mercedes = new Car("fghjk", 140.67);
            Car lambo = new Car("gfds", 220.23);
            Car fiesta = new Car("yuio", 23.20);

            HotelRoom suite = new HotelRoom("1001", 650);
            HotelRoom standard1 = new HotelRoom("65", 330);
            HotelRoom standard2 = new HotelRoom("65", 333);

            List<Rentable> rentableThings = new List<Rentable>();
            rentableThings.Add(mercedes);
            rentableThings.Add(lambo);
            rentableThings.Add(fiesta);
            rentableThings.Add(suite);
            rentableThings.Add(standard1);
            rentableThings.Add(standard2);


//james' way
            // foreach(Rentable thing in rentableThings)
            // {
            //     Console.WriteLine("if you rent this {0} for 1 day, you owe {1}",
            //     thing.GetType().Name,
            //     thing.calculateRent(1));
            // }
            foreach(Rentable thing in rentableThings)
            {
                String thingType = "";
                if(thing is Car)
                {
                    Car temp = (Car) thing;
                    thingType = "car";
                } 
                else if (thing is HotelRoom)
                {
                    thingType = "hotel room";
                }
            }


            Console.WriteLine("For car {0} for 1 day the amount due is {1}.", 
            mercedes.licenseNo, mercedes.calculateRent(1));

            Console.WriteLine("For car {0} for 1 day the amount due is {1}.", 
            lambo.licenseNo, lambo.calculateRent(1));

            Console.WriteLine("For car {0} for 1 day the amount due is {1}.", 
            fiesta.licenseNo, fiesta.calculateRent(1));

            Console.WriteLine("For room {0} for 1 day the amount due is {1}.", 
            suite.roomNo, suite.calculateRent(1));
            Console.WriteLine("For room {0} for 1 day the amount due is {1}.", 
            standard1.roomNo, standard1.calculateRent(1));
        }
    }

    public interface Rentable
    {
        //double getDailyRate();
        double calculateRent(double daysToRent);
    }

    public class Car : Rentable
    {
        public string licenseNo{get; private set;}
        public double hourlyRentalRate {get; private set;}
        //keeps track of particular instance of car for this attribute

        public Car(string LicenseNo, double rate)
        {
            this.licenseNo = LicenseNo;
            this.hourlyRentalRate = rate;
        }

        public double calculateRent(double daysToRent)
        {
            double dailyRate = 24*hourlyRentalRate;
            //instance of car already had hourlyRentalRate var so we dont have to pass
            return dailyRate*daysToRent;
        }
    }

    class HotelRoom : Rentable
    {
        public string roomNo {get; private set;}
        public double dailyRate{get; private set;}

        public HotelRoom(string RoomNo, double rate)
        {
            this.roomNo = RoomNo;
            this.dailyRate = rate;
        }
        public double calculateRent(double daysToRent)
        {
            return dailyRate * daysToRent;
        }

    }
}
