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
            Container Austin1 = new Container(3, "Austin 1");
            Container Austin2 = new Container(5, "Austin 2");
            Container Houston1 = new Container(3, "Houston 1");
            Container Houston2 = new Container(6, "Houston 2");
            Container Dallas1 = new Container(3, "Dallas 1");
            Container Dallas2 = new Container(6, "Dallas 2");
            Item bananas = new Item("Bananas", 2.43);
            Item apples = new Item ("Apples", 0.97);
            Item granolaBars = new Item("Granola Bars", 0.56);
            Item grapes = new Item("Grapes", 1.20);
            Item watermelon = new Item("Watermelon", 5.20);
            Item cereal = new Item("Cereal", 5.50);
            Item bread = new Item("Bread", 2.25);
            Item milk = new Item("Milk", 2.75);
            Item diapers = new Item("Diapers", 7.50);

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
            Austin1.items.Add(grapes);
            Austin1.items.Add(watermelon);
            Austin2.items.Add(cereal);
            Dallas1.items.Add(bread);
            Dallas1.items.Add(milk);
            Dallas2.items.Add(diapers);

            Manifest(Rainforest);
            Console.WriteLine("");
            Index(milk, Rainforest);

        }
        public static void Manifest(Company company)
        {
             Console.WriteLine("{0}", company.Name);

            foreach(Warehouse war in company.Warehouses)
            {
                Console.WriteLine("{0}".PadLeft(4), war.location);

                foreach (Container cont in war.containers)
                {
                    Console.WriteLine("{0}".PadLeft(8), cont.id);

                    foreach(Item it in cont.items)
                    {
                        Console.WriteLine("{0}".PadLeft(12), it.name);
                    }
                }
            }
        }

        public static void Index(Item item, Company company)
        {
            Dictionary<Item, Container> indexer = new Dictionary<Item, Container>();

            foreach(Warehouse war in company.Warehouses)
            {
                foreach(Container cont in war.containers)
                {
                    foreach (Item it in cont.items)
                    {
                        indexer.Add(it, cont);
                    }
                }
            }

            if (indexer.ContainsKey(item))
            {
                Container value = indexer[item];
                Console.WriteLine("{0} is found in {1}", item.name, value.id);
            }
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
