using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Jew can dew eet!!");
        }
    }

    public class Checker
    {
        public string Symbol  { get; }
        public int[] Position  { get; set; }
        public string Color { get; set; }
        
        public Checker(string color, int[] position)
        {
            this.Position = position;

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
        public string[][] Grid  { get; set; }
        public List<Checker> Checkers { get; set; }
        
        public Board()
        {
            string[,] gameGrid = new string[8,8];
            return;
        }
        
        public void CreateBoard()
        {
            // Your code here
            return;
        }
        
        public void GenerateCheckers()
        {
            // Your code here
            return;
        }
        
        public void PlaceCheckers()
        {
            // Your code here
            return;
        }
        
        public void DrawBoard()
        {
            // Your code here
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
