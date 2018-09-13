using System;
using Microsoft.Data.Sqlite;

namespace Checkpoint3
{
    public enum DoneStatus {undone, inProgress, done}
    class Item
    {
        int id {get; set;}
        string name {get; set;}
        string description {get; set;}
        DoneStatus Donestatus {get; set;}

        public Item (int Id, string Name, string Description, doneStatus DoneStatus)
        {
            id = Id;
            name = Name;
            description = Description;
            DoneStatus = DoneStatus;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SqliteConnectionStringBuilder stringBuilder = new SqliteConnectionStringBuilder();

            List<Item> toDoList = new List<Item>();
            Console.WriteLine("Please enter a line you'd like to enter into the list.");
        }
    }
}
