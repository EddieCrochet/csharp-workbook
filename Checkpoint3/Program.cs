using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Checkpoint3
{
    //////////////////////////////////////////////////////////////
    //this enum serves as a holder for the status of each item
    public enum DoneStatus {undone, In_Progress, done}

///////////////////////////////////////////////////
//each one of our items on our to do list will be an instance of the item class here
    public class Item
    {
        public int id {get; set;}
        public string name {get; set;}
        public string description {get; set;}

        public DoneStatus doneValue {get; set;}

        public Item (){}

        public Item (string Name, string Description, DoneStatus doneValue)
        //We don't pass in the ID because our SQL database will automaticall do that for us once connected
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
            ////////////////////////////////////////////////////////////////////
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
            ///////////////////////////////////////////////////////////////////////////////////////

            WelcomePrompt();
            CommandList();
            HomeScreen(toDoContext);
        }

        public static void HomeScreen(ToDoContext toDoContext)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////
            //this method being broken up allows me to have more control with calling these if statements
            //and not the list that came with it all on the welcome screen

            string value = Console.ReadLine();

            //
            //the following code allows the user to select a number that matches up with a command
            //

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
                Console.WriteLine();
                Console.WriteLine("Now what would like to do?");
                CommandList();
                HomeScreen(toDoContext);
            }
            else if(value == "4")
            {
                ListUnDone(toDoContext);
                Console.WriteLine();
                Console.WriteLine("Now what would like to do?");
                CommandList();
                HomeScreen(toDoContext);
            }
            else if(value == "5")
            {
                UpdateItem(toDoContext);
                Console.WriteLine();
                Console.WriteLine("What would you like to do now?");
                CommandList();
                HomeScreen(toDoContext);
            }
            else
            {
                ///////////////////////////////////////
                //what happens if the user offers an invalid entry
                
                Console.WriteLine("Please give me a valid entry like I listed for you.");
                HomeScreen(toDoContext);
            }
        }

        public static void WelcomePrompt()
        {
            /////////////////////////////////////////////////////////////////
            //simple prompt to welcome the user to the application

            Console.WriteLine("Welcome to your To Do List! Here is your home screen with a list of commands.");
            Console.WriteLine("Entering the following single numbers will execute that command.");
        }
        public static void CommandList()
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////
            //I provide the user a command list of controls to help navigate the app

            Console.WriteLine("1 - Add an item to your list.");
            Console.WriteLine("2 - Delete an item from your list.");
            Console.WriteLine("3 - List all done and unfinished items.");
            Console.WriteLine("4 - List only unfinished items.");
            Console.WriteLine("5 - Update an item already on your list.");
            Console.WriteLine();
        }
        public static void AddItem(ToDoContext toDoContext)
        {
            Console.WriteLine();
            /////////////////////////////////////////////////////////////////
            //this method adds an item to your list

            Console.WriteLine("Enter an item name to add to your list.");
            string inputName = Console.ReadLine();
            Console.WriteLine("Please enter a description for the item.");
            string inputDescription = Console.ReadLine();

            Item myItem = new Item(inputName, inputDescription, DoneStatus.undone);
            toDoContext.Items.Add(myItem);
            //throw in the user input for name and description into a new item instance
            //the default for our enum wil be undone
            //We then add that item to our connected DB Set
            /////////////////////////////////////////////////////////////////////////////////

            toDoContext.SaveChanges();
            Console.WriteLine();
            Console.WriteLine("What would you like to do now?");
            CommandList();
            HomeScreen(toDoContext);
        }
        static void DeleteItem(ToDoContext toDoContext)
        {
            Console.WriteLine();
            //////////////////////////////////////////////////////////////////
            //this method is used to delete items from your list

            ListAll(toDoContext);
            Console.WriteLine("Which item would you like to delete?");
            Console.WriteLine("Please enter the ID of that item.");

            int idValue = Convert.ToInt32(Console.ReadLine());

            ////
            //Item placeHoldItem = toDoContext.Items.First(s=>s.id.Equals(idValue));
            //thats how I had it before lolol works though
            //this way also works better for example in the update items function below
            ////

            Item placeHoldItem = toDoContext.Items.Find(idValue);
            //creates a new item instance and finds/matches it with the item of matching id in our DB Set
            //wooooooooooooow way easier
            /////////////////////////////////////////////////////////////////////////////////////////////////

            toDoContext.Items.Remove(placeHoldItem);
            //removes that selected item
            /////////////////////////////////////

            toDoContext.SaveChanges();
            Console.WriteLine();
            Console.WriteLine("What would you like to do now?");
            CommandList();
            HomeScreen(toDoContext);
        }
        public static void ListAll(ToDoContext toDoContext)
        {
            Console.WriteLine();
            /////////////////////////////////////////////////////////////////////////////
            //this method simply lists all things in the list with a linq query

            var results = from s in toDoContext.Items
            select s;

            foreach(Item s in results)
            {
                Console.WriteLine(s.id+" || "+s.name+" || "+s.description+" || "+s.doneValue);
            } 
        }
        static void ListUnDone(ToDoContext toDoContext)
        {
            Console.WriteLine();
            //////////////////////////////////////////////////////////////////////////////////////////////
            //this method lists all unfinished items in the list with another linq query

            var results = from s in toDoContext.Items where (s.doneValue == DoneStatus.undone)
            select s;

            foreach(Item s in results)
            {
                Console.WriteLine(s.id+" || "+s.name+" || "+s.description+" || "+s.doneValue);
            }
        }
        static void UpdateItem(ToDoContext toDoContext)
        {
            Console.WriteLine();
            ///////////////////////////////////////////////////////////////////////////////////
            //this method is used to update items in the list
            //it can be used to update the name, desctription, or status of being finished

            ListAll(toDoContext);
            Console.WriteLine("Which item would you like to update?");
            Console.WriteLine("Please enter the ID of that item.");
            int idValue = Convert.ToInt32(Console.ReadLine());
            Item placeHoldItem = toDoContext.Items.Find(idValue);
            //the same way we did above, this code allows the user to select an item to alter
            ///////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("Now which attribute would you like to update?");
            Console.WriteLine("Your choices are 'name', 'description', or 'done status'");

            string value = Console.ReadLine();
            //
            //this logic allows the user to select an attribute of that selected item to update
            //
            if(value == "name")
            {
                Console.WriteLine("What would you like this item's name to read?");
                string newName = Console.ReadLine();
                Item itemEntity = toDoContext.Items.First(s=>s.name.Equals(placeHoldItem.name));
                //
                //throws the new name into the selected item
                //
                itemEntity.name = newName;
                toDoContext.SaveChanges();
            }
            else if(value == "description")
            {
                Console.WriteLine("What would you like this item's description to read?");
                string newDescription = Console.ReadLine();
                Item itemEntity = toDoContext.Items.First(s=>s.description.Equals(placeHoldItem.description));
                //
                //throws the new description into the selected item
                //
                itemEntity.description = newDescription;
                toDoContext.SaveChanges();
            }
            else if(value == "done status")
            {
                Console.WriteLine("Press the corresponding key the change the status of the selected item.");
                Console.WriteLine("1 - undone");
                Console.WriteLine("2 - In_Progress");
                Console.WriteLine("3 - Done");
                //
                //once the user decides to change the status of a selected item
                //this code allows the user to decide which enum value they want to set it to, using an integer
                //
                string newStatusKey = Console.ReadLine();
                if(newStatusKey == "1")
                {
                    placeHoldItem.doneValue = DoneStatus.undone;
                    toDoContext.SaveChanges();
                }
                else if(newStatusKey == "2")
                {
                    placeHoldItem.doneValue = DoneStatus.In_Progress;
                    toDoContext.SaveChanges();
                }
                else if(newStatusKey == "3")
                {
                    placeHoldItem.doneValue = DoneStatus.done;
                    toDoContext.SaveChanges();
                }
            }
        }
    }
}
