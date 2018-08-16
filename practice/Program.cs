using System;

namespace practice
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
