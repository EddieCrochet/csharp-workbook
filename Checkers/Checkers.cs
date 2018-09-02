using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            Board boa = new Board();
            
            boa.GenerateCheckers();
            boa.DrawBoard();
            Console.WriteLine("Jew can dew eet!!");
        }
    }

    public class Checker
    {
        public string Symbol  { get; }
        public int[] Position  { get; set; }
        public string Color { get; }
        
        public Checker(string color, int[] position)
        {
            this.Position = position;
            this.Color = color;

            int openCircleId = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber);
            string openCircle = char.ConvertFromUtf32(openCircleId);
            int closedCircleId = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
            string closedCircle = char.ConvertFromUtf32(closedCircleId);
            //above code block creates the open and closed circle symbols and sets them to strings we can use


            if (color == "white")
            //white checkers will be designated by a closed circle
            {
                Symbol = closedCircle;
            }
            else if(color == "black")
            //black bircles wil be designated by an open circle
            {
                Symbol = openCircle;
            }
        }
    }

    public class Board
    {
        public List<Checker> Checkers { get; set; }
        
        public Board()
        {
            Checkers = new List<Checker>();
            return;
        }
        
        public void CreateBoard()
        {
            //your code here
            return;
        }
        
        public void GenerateCheckers()
        {
            //Generate white
            for (int i = 1; i < 8; i+=2)
            {
                Checker check = new Checker("white", new int[] {0, i});
                Checkers.Add(check);
            }
            for (int i = 0; i < 8; i+=2)
            {
                Checker check = new Checker("white", new int[] {1, i});
                Checkers.Add(check);
            }
            for (int i = 1; i < 8; i+=2)
            {
                Checker check = new Checker("white", new int[] {2, i});
                Checkers.Add(check);
            }

            //Generate Black
            for (int i = 0; i < 8; i+=2)
            {
                Checker check = new Checker("black", new int[] {5, i});
                Checkers.Add(check);
            }
            for (int i = 1; i < 8; i+=2)
            {
                Checker check = new Checker("black", new int[] {6, i});
                Checkers.Add(check);
            }
            for (int i = 0; i < 8; i+=2)
            {
                Checker check = new Checker("black", new int[] {7, i});
                Checkers.Add(check);
            }
            return;
        }
    
        public void PlaceCheckers()
        {
            // Your code here
            return;
        }
        
        public void DrawBoard()
        {
            Console.WriteLine(" 01234567");
            for (int i = 0; i < 8; i++)
            {
                Console.Write(i);

                foreach (Checker c in Checkers)
                {
                    int x = c.Position[0];
                    int y = c.Position[1];

                    if (x == i)
                    {
                        Console.Write("".PadLeft(y) + c.Symbol);
                    }
                }

                Console.WriteLine();
            }
            return;
        }
        
        public Checker SelectChecker(int row, int column)
        {
            return Checkers.Find(x => x.Position.SequenceEqual(new List<int> { row, column }));
        }
        
        public void RemoveChecker(int row, int column)
        {
            // Your code here
            return;
        }
        
        public bool CheckForWin()
        {
            return Checkers.All(x => x.Color == "white") || !Checkers.Exists(x => x.Color == "white");
        }
    }

    class Game
    {
        public Game()
        {
            // Your code here
        }
    }
}
