using System;
using System.Collections.Generic;

namespace practice
{
    class Program
    {
        public static void Main(string[] args)
        {
            Sedan myMazda = new Sedan();
            Truck jasonsTruck = new Truck();
            Vehicle lisasPrius = new Sedan();
            //even though made with a sedan constructor, this is NOT a sedan... it is a vehicle

            List<Vehicle> listOfVehicle = new List<Vehicle>();
            listOfVehicle.Add(myMazda);
            listOfVehicle.Add(lisasPrius);
            listOfVehicle.Add(jasonsTruck);

            Console.WriteLine("myMazda: "+myMazda.honk());
            Console.WriteLine("lisasPrius: "+lisasPrius.honk());

            //THIS IS CASTING
            foreach(Vehicle v in listOfVehicle)
            {
                if(v is Truck)
                {
                    Truck theTruck = (Truck) v;
                    Console.WriteLine(theTruck.dump());
                } 
                else
                {
                    Console.WriteLine("is not a truck");
                }
            }

        }
    }

    public abstract class Vehicle
    {
        public abstract string honk();
        //must define method for abstract honk
    }

    public class Sedan : Vehicle
    {
        public override string honk()
        //new brings it back to what is the variable type
        //override tells us to focus on what the instance is
        {
            return "beeeep. beep.";
        }
    }

    public class Truck : Vehicle
    {
        public override string honk()
        {
            return "HONK BRO!!!!";
        }

        public String dump()
        {
            return "dumping stuff!";
        }
    }
}
