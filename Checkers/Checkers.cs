using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            Game game = new Game();
        }
    }

    public class Checker
    {
        public string Symbol  { get;}
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
        //all the board has is a list of checkers
        
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
            //Generate white - one row at a time
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

            //Generate Black - one row at a time
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
    //this method actually moves the chekers
            Console.WriteLine("Enter Pickup Row:");
            int x1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Pickup Column:");
            int y1 = Convert.ToInt32(Console.ReadLine());
            //x1 and y1 are the original spot in that turn for the checkers to be moved

            Console.WriteLine("Enter Placement Row:");
            int x2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Placement Column");
            int y2 = Convert.ToInt32(Console.ReadLine());
            //x2 and y2 are the coordinates the checker will be moved to

            Checker check = SelectChecker(x1,y1);

            int WorB = 0;
            if(check.Color == "None")
            {
                Console.WriteLine("There is no checker in that spot.");
                return;
            }
            if(check.Color == "White")
            {
                WorB = 1;
            }
            else if (check.Color == "Black")
            {
                WorB = -1;
            }

            if ((x2 < 8) && (x2 > 0) && (y2 < 8) && (y2 > 0)) 
            {
                if ((x2 == x1+1) || (x2 == x1-1) && (y2 == y1+WorB))
                {
                    Checker newSpace = SelectChecker(x2,y2);
                    if (check.Color == newSpace.Color)
                    {
                        Console.WriteLine("That spot is a friendly checker, You can't move there.");
                        return;
                    }
                    else if (check.Color != newSpace.Color)
                    {
                        //jump
                    }
                    else if (newSpace.Color == "None") 
                    {
                        CheckForWin();
                    }
                } 
                else 
                {
                    //fails, not a diagonal-one-away-space
                }
            } 
            else 
            {
                //fails, selected space out of board bounds   
            }

            /*
            
                        //check for checker at location
                        foreach (Checker c in Checkers)
                        {
                            if (c.Position[0] == x2 && c.Position[1] == y2)
                            //if the spot is taken return the messgae and begin turn again
                            {
                                Console.WriteLine("There is already a checker at that location!");
                                return; // this ends the function
                            }
                        }

             */

            
            //if it's availeable to move there, this is the actual coordinate switch

            check.Position[0] = x2;
            check.Position[1] = y2;

            DrawBoard();

            return;
        }
        
        public void DrawBoard()
        {
            string[,] grid = new string[8,8];
//TRY/CATCH FOR OUT OF BOUNDS

            //our grid that will hold our checkers
            Console.WriteLine("\t0\t1\t2\t3\t4\t5\t6\t7\t");
            //tabs to get the y axis to be even with the checker spot on the grid
            foreach (Checker check in Checkers)
            {
                int x = check.Position[0];
                int y = check.Position[1];

                grid[x,y] = check.Symbol;
                //draws the symbol of that checker for every spot on the grid that is taken
            }

            for (int i=0;i<8;i++)
            {
                Console.Write("{0}\t", i);
                for (int j=0;j<8;j++)
                {
                    Console.Write("{0}\t",grid[i,j]);
                    //prints out our x axis from the grid and once again spaces them accordingly
                }
                Console.Write("\n");
            }
        }
        
        public Checker SelectChecker(int row, int column)
        {
            try 
            {
                return Checkers.Find(x => x.Position.SequenceEqual(new List<int> { row, column }));
            } 
            catch 
            {
                Checker newChecker = new Checker("None", new int[] {row, column});
                return newChecker;
            }            
        }
        
        public void RemoveChecker(int row, int column)
        {
            // Your code here
            return;
        }
        
        public bool CheckForWin()
        {
            return Checkers.All(x => x.Color == "White") || !Checkers.Exists(x => x.Color == "White");
            //if only one color of checker is left on the board, that team will win!
        }
    }

    class Game
    {
        public Game()
        {
            Board board = new Board();

            board.GenerateCheckers();

            board.DrawBoard();

            while (!board.CheckForWin())
            {
                board.PlaceCheckers();
            }
        }
    }
}
