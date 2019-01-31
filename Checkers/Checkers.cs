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
            //needed to allow the utf8 symbols...
            
            Game game = new Game();
            //all we do in the main is instantiate the game
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

        public void GenerateCheckers()
        {
            //Generate white - one row at a time, as there is a different mathematical formula for each row.
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
            Checker check;
            try 
            {
                check = SelectChecker(x1,y1);
                //uses the first two coordinates from the user in this turn
                //to see if there is a checker there that can be moved
            }
            catch 
            {
                Console.WriteLine("There is no checker in that spot.");
                return;
            }


            int WorB = 0;
            //this integer helps us change the math easily for white or black checkers moving on the grid
            if(check.Color == "white")
            {
                WorB = 1;
            }
            else if (check.Color == "black")
            {
                WorB = -1;
            }

            if ((x2 <= 7) && (x2 >= 0) && (y2 <= 7) && (y2 >= 0)) 
            //first of all, the move needs to be within the parameters of our board
            {
                //on the board
                if ((y2 == y1+1) || (y2 == y1-1) && (x2 == x1+WorB))
                {
                    //one way diagonal spot
                    Checker newSpace;

                        //see if we find a checker in the target spot
                        newSpace = SelectChecker(x2,y2);

                        Console.WriteLine("no checker found in space");
                        //if no checker present, move 1 diagonally

                        check.Position[0] = x2;
                        check.Position[1] = y2;

                        DrawBoard();
                        //redraw pur board to re-place checkers

                    //if a cheker is found in the spot
                    if(newSpace != null) 
                    {
                        if (check.Color == newSpace.Color)
                        {
                            Console.WriteLine("That spot is a friendly checker, You can't move there.");
                            return;
                        }
                        else if (check.Color != newSpace.Color)
                        //your move to coordinates need to be ON the enemy checker in order to jump
                        //but you do end up in the right spot
                        {
                            //jump action
                            check.Position[0] = (x2-x1)+x2;
                            //math to move the checkers coordinates
                            check.Position[1] = (y2-y1)+y2;
                            //remove opponent checker
                            Checkers.Remove(newSpace);
                            Console.WriteLine("You take their checker!");
                            Console.WriteLine();
                            DrawBoard();
                            //redraw board again to re-place our checkers

                            return;
                        }
                    }
                    return;
                } 
                else 
                {
                    DrawBoard();
                    Console.WriteLine("Not a legal move, try again!");
                    return;
                }
            } 
            else 
            {
                DrawBoard();
                Console.WriteLine("Fool that's not even on the board, try again!"); 
                return;
            }        
        }
        
        public void DrawBoard()
        {
            string[,] grid = new string[8,8];
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
            return Checkers.Find(x => x.Position.SequenceEqual(new List<int> { row, column }));
        }

        public bool CheckForWin()
        {
            bool isWin = false;
            if (Checkers.All(x => (x.Color == "white") || (x.Color == "None"))) {
                isWin = true;
            }
            if (Checkers.All(x => (x.Color == "black") || (x.Color == "None"))) {
                isWin = true;
            }
            return isWin;
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
