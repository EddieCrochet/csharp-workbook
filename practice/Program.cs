using System;
using System.Collections;
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

    
    {
        static void Main(string[] args)
        {
            Student jason = new Student("Jason C", "Dec 17");
            Student jasonClone = new Student("Jason C", "Dec 17");
            //creating a new instance makes it NOT the same thing anymore
            Student sameJason = jason;

            Console.WriteLine("Is jason equals jason? {0}", jason.Equals(jason));
            Console.WriteLine("Is jason equals jasonClone? {0}", jason.Equals(jasonClone));
            Console.WriteLine("Is jason equals sameJason? {0}", jason.Equals(sameJason));

            String x = "my String";
            String y = "my String";
            //for string equality it just checks the strings themselves, not the instances

            Console.WriteLine("is x equals to y? {0}", x.Equals(y));


            Stack things = new Stack();
            //not a stack of strings
            //not a stack of students
            //general stack of objects

            things.Push(x);
            things.Push(y);
            things.Push(jason);
            things.Push(jasonClone);
        }
    }

    public class Cohort<T>
    //the letter T is generic that means general same type of things
    {
        List<T> theCohort;
        //list of the things in my cohort
        String name;
        DateTime theDate;
        public T getFirst()
        {
            if (theCohort == null || theCohort.Count== 0)
            {
                return default(T);
                //default return null?
                //when you say its generic it doesnt have to be a class
                //could be anything
                //there are no null int
                //why you cant return null
                //default return the same way as null but for generics
            }
            else
            {
                return theCohort[0];
            }
        }
    }
    public class Student
    {
        String name{get;}
        String dob{get;}

        public Student(String name, String dob)
        {
            this.name = name;
            this.dob = dob;
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
            Vehicle veh = new Vehicle(40, 4, 5);
            Vehicle myTruck = new Truck(50, 500, 50, 3, 5);

            Console.WriteLine("Veh: " +veh.hydraulics());
            Console.WriteLine("myTruck: " +myTruck.hydraulics());
        }
    }

    class Vehicle
    {
        public int engineSize;
        public int numTires;
        public int passengerCapacity;

        public Vehicle(int engineSize, int numTires, int passengerCapacity)
        {
            this.engineSize = engineSize;
            this.numTires = numTires;
            this.passengerCapacity = passengerCapacity;
        }

        public virtual string hydraulics()
        {
            return "and we bumpin";
        }
    }

    class Truck : Vehicle
    {
        int bedSize;
        int towingCapacity;

        public Truck(int bedSize, int towingCapacity, int engineSize, int numTires, int passengerCapacity)
        :base(engineSize, numTires, passengerCapacity)
        {
            this.bedSize = bedSize;
            this.towingCapacity = towingCapacity;
        }

        public override string hydraulics()
        {
            return "so much power that it got some air!";
        }
    }

    class Sedan : Vehicle
    {
        bool luxury;

        public Sedan(bool luxury, int engineSize, int passengerCapacity)
        : base(engineSize, 4, passengerCapacity)
        {
            this.luxury = luxury;
        }
    }

    class Motorcycle : Vehicle
    {
        bool cruiser;

        public Motorcycle(bool cruiser, int engineSize, int passengerCapacity)
        : base(engineSize, 2, passengerCapacity)
        {
            this.cruiser = cruiser;


        public static void Main (String[] args)
        {
            Console.WriteLine("Hello Drivers License Practice");

            String someName = "Eddie";
            int someHeight = 66;
            String someLN = "AB87654567TX";

            int numberLicenses = 0;

            DriversLicense myLicense = new DriversLicense(someName, someHeight, someLN);

            DriversLicense otherLicense = new DriversLicense("John", 75, "DL876");
            otherLicense.eyeColor = "brown";
            //Console.WriteLine("{0} is {1} inches tall", otherLicense.name, otherLicense.heightInInches);
            Console.WriteLine("{0} is {1} feet tall and has {2} eyes", otherLicense.name, otherLicense.heightInFeet(), otherLicense.eyeColor);

            Console.WriteLine("We have created {0} licenses", DriversLicense.numberLicenses);
        }
    }


    class DriversLicense
    {
        //static means its available to the class not to a particular instance
        public static int numberLicenses;

        public String name {get; set;}
        public int heightInInches {get; set;}
        public String eyeColor {get; set;}
        public String hairColor {get; set;}
        public char gender {get; set;}
        public String driversLicenseClass {get; set;}
        public String DOB {get; set;}
        public String driversLicenseNumber {get; private set;}
        public bool organDonor {get; set;}
        public String state {get; set;}

        public DriversLicense (string _name, int _heightInInches, string _eyeColor)
        {
            this.name = _name;
            this.heightInInches = _heightInInches;
            this.eyeColor = _eyeColor;
            //this.hairColor = _hairColor;
            //this.gender = _gender;
            //this.driversLicenseClass = _driversLicenseClass;
            //this.DOB = _DOB;
            //this.driversLicenseNumber = _driversLicenseNumber;
            //this.organDonor = _organDonor;
            //this.state = _state;
            numberLicenses ++;

        }

        public double heightInFeet()
        {
            double feet = this.heightInInches/12.0;
            //forces division of integer by decimal
            return feet;
        }

        static void Main(string[] args)
        {
//GOT TO CALL THE FUNCTIONS HERE (or wherever you want them)
substringExample();
IndexOfExample();
JoinExample();
        }

        static void substringExample()
        {
            string haystack = "some long string";
            int index = 3;
            int length = 10;
            string subString1 = haystack.Substring(index);
            string subString2 = haystack.Substring(index, length);
            Console.WriteLine("substring1 = {0}", subString1);
            Console.WriteLine("substring2 = {0}", subString2);
        }

        static void IndexOfExample()
        {
            string haystack = "The quick brown fox jumps over the lazy dog.";
            string needle = "a";
            int index = haystack.IndexOf(needle);
            Console.WriteLine("found the needle starting at position {0}", index );
        }
           
        static void JoinExample()
        {
            string fname = "John";
            string lname = "Doe";
            string mname = "Billy";

            string[] nameParts = new string[3];
            nameParts[0] = fname;
            nameParts[1] = mname;
            nameParts[2] = lname;

            string separator = " ";

            String fullName = String.Join(separator, nameParts);
            Console.WriteLine(fullName);
        }
    }
}
