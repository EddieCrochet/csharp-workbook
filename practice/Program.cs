using System;

namespace practice
{
    class Program
    {

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

    }
}
