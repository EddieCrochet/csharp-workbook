using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Checkpoint3
{
    public enum DoneStatus {undone, inProgress, done}
    public class Item
    {
        public int id {get; set;}
        public string name {get; set;}
        public string description {get; set;}
        DoneStatus privateObj;

        public DoneStatus doneValue
        {
            get
            {
                return privateObj;
            }
            set
            {
                privateObj = value;
            }
        }

        public Item (){}

        public Item (string Name, string Description, DoneStatus doneValue)
        {
            name = Name;
            description = Description;
        }
    }

    public class ToDoContext : DbContext
    {
        public DbSet<Item> Items {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //this is where I will specify the path to the database
            optionsBuilder.UseSqlite("Filename=./toDo.db");
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            ToDoContext toDoContext = new ToDoContext();
            toDoContext.Database.EnsureCreated();
            //connects the database and hold the logic to have the database created from my class

            HomeScreen();
            string value = Console.ReadLine();
            if (value == "1")
            {
                AddItem(toDoContext);
            }
            else if(value == "2")
            {
                DeleteItem(toDoContext);
            }
            else if(value == "3")
            {
                ListAll(toDoContext);
            }
            else if(value == "4")
            {
                ListUnDone(toDoContext);
            }
            else if(value == "5")
            {
                UpdateItem(toDoContext);
            }
        }
        public static void HomeScreen()
        {
            //I provide the user a home screen with the list of controls to help navigate the app
            Console.WriteLine("Welcome to your To Do List! Here is your home screen with a list of commands.");
            Console.WriteLine("Entering the following single numbers will execute that command.");
            Console.WriteLine("1 - Add an item to your list.");
            Console.WriteLine("2 - Delete an item from your list.");
            Console.WriteLine("3 - List all done and unfinished items.");
            Console.WriteLine("4 - List only unfinished items.");
            Console.WriteLine("5 - Update an item already on your list.");
            Console.WriteLine();
        }
        public static void AddItem(ToDoContext toDoContext)
        {
            //this method adds an item to your list
            Console.WriteLine("Enter an item name to add to your list.");
            string inputName = Console.ReadLine();
            Console.WriteLine("Please enter a description for the item.");
            string inputDescription = Console.ReadLine();

            Item myItem = new Item(inputName, inputDescription, DoneStatus.undone);
            toDoContext.Items.Add(myItem);
            toDoContext.SaveChanges();
        }
        static void DeleteItem(ToDoContext toDoContext)
        {
            //this method is used to delete items from your list
            ListAll(toDoContext);
            Console.WriteLine("Which item would you like to delete?");
            Console.WriteLine("Please enter the ID of that item.");
            int idValue = Convert.ToInt32(Console.ReadLine());
            Item placeHoldItem = toDoContext.Items.First(s=>s.id.Equals(idValue));
            //a linq query above selects the specifed item by ID to be deleted
            toDoContext.Items.Remove(placeHoldItem);
            toDoContext.SaveChanges();
        }
        public static void ListAll(ToDoContext toDoContext)
        {
            //this method simply lists all things in the list
            var results = from s in toDoContext.Items
            select s;

            foreach(Item s in results)
            {
                Console.WriteLine(s.id+" || "+s.name+" || "+s.description+" || "+s.doneValue);
            } 
        }
        static void ListUnDone(ToDoContext toDoContext)
        {
            //this method lists all unfinished items in the list
            var results = from s in toDoContext.Items where (s.doneValue == DoneStatus.undone)
            select s;

            foreach(Item s in results)
            {
                Console.WriteLine(s.id+" || "+s.name+" || "+s.description+" || "+s.doneValue);
            }
        }
        static void UpdateItem(ToDoContext toDoContext)
        {
            //this method is used to update items in the list
            //it can be used to update the name, desctription, or status of being finished
            ListAll(toDoContext);
            Console.WriteLine("Which item would you like to update?");
            Console.WriteLine("Please enter the ID of that item.");
            int idValue = Convert.ToInt32(Console.ReadLine());
            Item placeHoldItem = toDoContext.Items.First(s=>s.id.Equals(idValue));
            Console.WriteLine("Now which attribute would you like to update?");
            Console.WriteLine("Your choices are 'name', 'description', or 'done status'");

            string value = Console.ReadLine();
            if(value == "name")
            {
                Console.WriteLine("What would you like this item's name to read?");
                string newName = Console.ReadLine();
                Item itemEntity = toDoContext.Items.First(s=>s.name.Equals(s.name));
                itemEntity.name = newName;
                toDoContext.SaveChanges();
            }
            else if(value == "description")
            {
                Console.WriteLine("What would you like this item's description to read?");
                Item itemEntity = toDoContext.Items.First(s=>s.description.Equals(value));
                toDoContext.Items.Add(itemEntity);
                toDoContext.SaveChanges();
            }
        }
    }
}
