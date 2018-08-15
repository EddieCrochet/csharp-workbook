using System;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		Person leia = new Person("Leia", "Organa", "Rebel");
		Person darth = new Person("Darth", "Vader", "Imperial");
		Person luke = new Person("Luke", "Skywalker", "Rebel");
		Person han = new Person("Han", "Solo", "Rebel");
		Person palp = new Person("Emporer", "Palpatine", "Imperial");
		Ship x = new Ship("xwing", "Rebel", "fighter", 2);
		Ship falcon = new Ship("MilFal", "Rebel", "Smuggling", 2);
		Ship tie = new Ship("TieFie", "Tie", "Fighter", 1);
		Station station1 = new Station("Rebel Space Station", "Rebel", 3);
		Station station2 = new Station("Death Star", "Imperial", 3);

		x.EnterShip(luke,0);
		x.EnterShip(han,1);

		station1.DockShip(x,1);
		Roster(station1);
	}

	private static void Roster(Station station)
	{
		foreach (KeyValuePair<int, Ship> ships in station.Docked)
		{
			Console.WriteLine("Ship {0} contains:", ships.Value.Name);
			Console.WriteLine("{0}", ships.Value.Passengers);
		}
	}
}

class Person
{
	private string firstName;
	private string lastName;
	private string alliance;
	public Person(string firstName, string lastName, string alliance)
	{
		this.firstName = firstName;
		this.lastName = lastName;
		this.alliance = alliance;
	}

	public string FullName
	{
		get
		{
			return this.firstName + " " + this.lastName;
		}

		set
		{
			string[] names = value.Split(' ');
			this.firstName = names[0];
			this.lastName = names[1];
		}
	}
}

class Ship
{
	private Person[] passengers;
	public Ship(string name, string alliance, string type, int size)
	{
		this.Name = name;
		this.Type = type;
		this.Alliance = alliance;
		this.passengers = new Person[size];
	}

	public string Name
	{
		get;
		set;
	}

	public string Type
	{
		get;
		set;
	}

	public string Alliance
	{
		get;
		set;
	}

	public string Passengers
	{
		get
		{
			foreach (var person in passengers)
			{
				Console.WriteLine(String.Format("{0}", person.FullName));
			}

			return "That's Everybody!";
		}
	}

	public void EnterShip(Person person, int seat)
	{
		this.passengers[seat] = person;
	}

	public void ExitShip(int seat)
	{
		this.passengers[seat] = null;
	}
}

class Station
{
	public string Name {get; set;}
	public string Alliance {get; set;}
	public int Size {get; set;}
	public Dictionary<int, Ship> Docked = new Dictionary<int, Ship>();

	public Station(string name, string alliance, int size)
    {
        this.Name = name;
        this.Alliance = alliance;
    }

	public void DockShip(Ship ship, int port)
	{
		Docked.Add(port, ship);
	}

	public void UnDockShip(Ship ship, int port)
	{
		Docked.Remove(port);
	}
}