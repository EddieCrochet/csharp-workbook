using System;

namespace TicTacToe
{
    class Program
    {
        public static string playerTurn = "X";
        public static string[][] board = new string[][]
        {
            new string[] {" ", " ", " "},
            new string[] {" ", " ", " "},
            new string[] {" ", " ", " "}
        };

        public static void Main()
        {
            do
            {   
                //swap indiscriminate means even if inout in invalid we swap
                //swap player turn... let getinput swap player turn at end
                //make getinput retun true or false adn use that t/f to determine weather we swap or not
                DrawBoard();
                GetInput();

            } while (!CheckForWin() && !CheckForTie());

            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }

        public static void GetInput()
        {
            Console.WriteLine("Player " + playerTurn);
            Console.WriteLine("Enter Row:");
            int row = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Column:");
            int column = int.Parse(Console.ReadLine());
            PlaceMark(row, column);
        }

        public static void PlaceMark(int row, int column)
        {
        // your code goes here

        }

        public static bool CheckForWin()
        {
            // your code goes here
        bool won = false;
        if(HorizontalWin() || VerticalWin() || DiagonalWin())
        {
            won = true;
        }
            return won;
        }

        public static bool CheckForTie()
        {
            // your code goes here

            return false;
        }
        
        public static bool HorizontalWin()
        {
        // your code goes here

        return false;
        }

        public static bool VerticalWin()
        {
            // your code goes here

            return false;
        }

        public static bool DiagonalWin()
        {
            // your code goes here

            return false;
        }

        public static void DrawBoard()
        {
            Console.WriteLine("  0 1 2");
            Console.WriteLine("0 " + String.Join("|", board[0]));
            Console.WriteLine("  -----");
            Console.WriteLine("1 " + String.Join("|", board[1]));
            Console.WriteLine("  -----");
            Console.WriteLine("2 " + String.Join("|", board[2]));
        }
    }
}
