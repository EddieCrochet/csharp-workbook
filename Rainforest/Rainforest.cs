using System;
using System.Collections.Generic;

namespace Rainforest
{
    class Program
    {
        static void Main(string[] args)
        {
            Company Rainforest = new Company("Rainforest");
            Warehouse Austin = new Warehouse("Austin", 3);
            Warehouse Dallas = new Warehouse("Dallas", 4);
            Warehouse Houston = new Warehouse("Houston", 5);
            Container Austin1 = new Container(3, "fruit");
            Container Austin2 = new Container(5, "non-perishable");
            Container Houston1 = new Container(3, "fruit");
            Container Houston2 = new Container(6, "non-perishable");
            Container Dallas1 = new Container(3, "fruit");
            Container Dallas2 = new Container(6, "non-perishable");
            Item bananas = new Item("Bananas", 2.43);
            Item apples = new Item ("Apples", 0.97);
            Item granolaBars = new Item("Granola Bars", 0.56);

            //NEED TO ADD ITEMS INTO ALL CONTAINERS!!!!

            Rainforest.Warehouses.Add(Austin);
            Rainforest.Warehouses.Add(Dallas);
            Rainforest.Warehouses.Add(Houston);
            Austin.containers.Add(Austin1);
            Austin.containers.Add(Austin2);
            Dallas.containers.Add(Dallas1);
            Dallas.containers.Add(Dallas2);
            Houston.containers.Add(Houston1);
            Houston.containers.Add(Houston2);
            Houston1.items.Add(bananas);
            Houston1.items.Add(apples);
            Houston2.items.Add(granolaBars);
            Austin1.items.Add(bananas);
            Austin1.items.Add(apples);
            Austin2.items.Add(granolaBars);
            Dallas1.items.Add(bananas);
            Dallas1.items.Add(apples);
            Dallas2.items.Add(granolaBars);


            Console.WriteLine("the build was so far successful!");
        }
    }

    class Company
    {
        public string Name {get; set;}
        public List<Warehouse> Warehouses = new List<Warehouse>();

        public Company(string Name)
        {
            this.Name = Name;
        }
    }

    class Warehouse
    {
        public string location {get; set;}
        public int size {get; set;}
        public List<Container> containers = new List<Container>();

        public Warehouse(string location, int size)
        {
            this.location = location;
            this.size = size;
        }
    }

    class Container
    {
        public int size {get; set;}
        public string id {get; set;}
        public List<Item> items = new List<Item>();

        public Container(int size, string id)
        {
            this.size = size;
            this.id = id;
        }
    }

    class Item
    {
        public string name {get; set;}
        public double price {get; set;}

        public Item(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
    }
}
