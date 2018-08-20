using System;
using System.Collections.Generic;

namespace Mastermind
{
    class Program
    {
        // possible letters in code
        public static char[] letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
        
        // size of code
        public static int codeSize = 4;
        
        // number of allowed attempts to crack the code
        public static int allowedAttempts = 10;
        
        // number of tried guesses
        public static int numTry = 0;
        
        // test solution
        public static char[] solution = new char[] {'a', 'b', 'c', 'd'};
        
        // game board
        public static string[][] board = new string[allowedAttempts][];
        
        
        public static void Main(string[] args)
        {
            CreateBoard();
            DrawBoard();
            Console.WriteLine("Enter Guess:");
            
            Game game = new Game(new string[]{"a", "b", "c", "d"});

            for(int turns = 10; turns > 0; turns--)
            {
                Console.WriteLine($"You have {turns} tries left");
                Console.WriteLine("Choose four letters");
                string letters = Console.ReadLine();
                Ball[] balls = new Ball[4];
                for(int i = 0; i < 4; i++)
                {
                    balls[i] = new Ball(letters[i].ToString());
                }
                CheckSolution(balls);
                if(CheckSolution(balls))
                {
                    break;
                }
                //for every turn we are going to check the solution
                Row row = new Row(balls);
                game.AddRow(row);
                Console.WriteLine(game.Rows);
            }
            Console.WriteLine("Out of turns!");

            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }
        
        public static bool CheckSolution(Ball[] guess)
        {
            if(guess == solution)
            {
                Console.WriteLine("You won the game!");
                return true;
            }

            return false;
        }
        
        public static string GenerateHint(char[] guess)
        {
            // Your code here
            return " ";
        }
        
        public static void InsertCode(char[] guess)
        {
            // Your code here
        }
        
        public static void CreateBoard()
        {
            for (var i = 0; i < allowedAttempts; i++)
            {
                board[i] = new string[codeSize + 1];
                for (var j = 0; j < codeSize + 1; j++)
                {
                    board[i][j] = " ";
                }
            }
        }
        
        public static void DrawBoard()
        {
            for (var i = 0; i < board.Length; i++)
            {
                Console.WriteLine("|" + String.Join("|", board[i]));
            }
            
        }
        
        public static void GenerateRandomCode() {
            Random rnd = new Random();
            for(var i = 0; i < codeSize; i++)
            {
                solution[i] = letters[rnd.Next(0, letters.Length)];
            }
        }
    }

    class Ball 
    {
        public string Letter {get; private set;}
        //stores what letter the ball is representing

        public Ball(string letter)
        //constructor passes the letters
        {
            this.Letter = letter;
        }
    }

    class Row
    {
        public Ball[] balls = new Ball[4];
        //four balls in one row (or turn)

        public Row(Ball[] balls)
        //the constructor passes the balls
        {
            this.balls = balls;
        }
        public string Balls
        {
            get
            {
                foreach (var ball in this.balls)
                {
                    Console.Write(ball.Letter);
                    //for each ball in this char array called balls, it will print the letter of the ball
                }
                return "";
            }
        }
    }
    class Game
    {
        private List<Row> rows = new List<Row>();
        public string[] answer = new string[4];

        public Game(string[] answer)
        {
            this.answer = answer;
        }
        private string Score (Row row)
        //method to keep the score
        {
            string[] answerClone = (string[]) this.answer.Clone();
            int red = 0;
            for(int i = 0; i < 4; i++)
            //loops to check the letter of each of the balls in the turn
            {
                if (answerClone[i] == row.balls[i].Letter)
                //checking each of the balls letters in the anser clone
                {
                    red++;
                    //if it's right, add one value to the 'red' counter
                }
            }
            int white = 0;
            for(int i = 0; i < 4; i++)
            //loops to check the location of each of the balls in the row (turn)
            {
                int foundIndex = Array.IndexOf(answerClone, row.balls[i].Letter);
                //foundIndex will represent each separate ball in the loop for that row
                //and will grab the letter of it to check against correct answer
                if(foundIndex > -1)
                {
                    white++;
                    answerClone[foundIndex] = null;
                }
            }
            return $"{red} - {white - red}";
        }
        public void AddRow (Row row)
        {
            this.rows.Add(row);
        }
        public string Rows
        {
            get
            {
                foreach(var row in this.rows)
                {
                    Console.Write(row.balls);
                    Console.WriteLine(Score(row));
                }
                return"";
            }
        }
    }
}
