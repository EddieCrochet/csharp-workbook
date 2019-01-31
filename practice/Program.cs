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
