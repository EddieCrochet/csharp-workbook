using System;
using System.Collections.Generic;

namespace Checkpoint2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("build successful so far!");
        }
    }
    public enum Color {white, black}
    //my enumeral for the color
    public struct Point
    //a struct called point to represent the checkers spot on the grid
    {
        public int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    
    class Checker
    {
        public Color color {get;}
        //need to write a loop here that randomly creates half the checkers one color or another???
        //also in that loop link the symbol (open or closed) to it's corresponding color?
        //the color will not be settable - once created it is that
        public Point coordinates{get; set;}
        public string symbol{get;}

        public Checker(Color color, Point coordinates, string symbol)
        {
            this.color = color;
            this.coordinates = coordinates;
            this.symbol = symbol;
        }

    }

    class Board
    {
        public List<Checker> checkers = new List<Checker>();
    }

    class Game
    {

    }
}
