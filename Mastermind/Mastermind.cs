using System;
using System.Collections.Generic;

namespace Mastermind
{
    class Ball
    {
        public string Letter{get; private set;}

        public Ball (string letter)
        {
            this.Letter = letter;
        }
    }
    class Row
    {
        public Ball[] balls = new Ball[4];
        //creates array of 4 of the Ball class

        public Row (Ball[] balls)
        {
            this.balls = balls;
        }

        public string Balls
        {get
        {foreach(var ball in this.balls)
            {
                Console.WriteLine(ball.Letter);
            }
        return "";
        }
        }
    }

    class Game
    {
        public List<Row> rows = new List<Row>();
        //creates a private list of the Row class
        private string[] answer = new string[4];
        //create a new array of strings with the size of 4 to hold our answer

        public Game(string[] answer)
        {
            this.answer = answer;
        }

        public string Score (Row row)
        {
            string[] answerClone = (string[]) this.answer.Clone ();
            // red is correct letter and correct position
            // white is correct letters minus red
            // this.answer => ["a", "b", "c", "d"]
            // row.balls => [{ Letter: "c" }, { Letter: "b" }, { Letter: "d" }, { Letter: "a" }]
            int red = 0;
            for (int i = 0; i<4; i++)
            {
                if (answerClone[i] == row.balls[i].Letter)
                red++;
            }
            int white = 0;
            for(int i = 0; i<4; i++)
            {
                int foundIndex = Array.IndexOf(answerClone, row.balls[i].Letter);
                if(foundIndex > -1)
                {
                    white++;
                    answerClone[foundIndex] = null;
                }
            }
            return $"{red} - {white - red}";
        }
    }
    class program
    {
        public static void Main(string[] args)
        {
            Game game = new Game(new string[] {"a", "b", "c", "d"});
            for (int turns = 10; turns > 0; turns--)
            {
                Console.WriteLine("You have {0} tries left!", turns);
                Console.WriteLine("Choose four letters: ");
                string letters = Console.ReadLine();
                //reads the chosen letters as a string letters
                Ball[] balls = new Ball[4];
                for (int i = 0; i<4; i++)
                //checks each one of the balls
                {
                    balls[i] = new Ball(letters[i].ToString());
                    //each of the 4 balls created in the array are assigned to a string of one letter
                    //the letters come from string the user typed in and entered to the string letters
                }
                Row row = new Row(balls);
                //makes a new Row called row where we pass in the users' balls, all now in their own separate strings
                game.rows.Add(row);
                //add the row of the new balls we created to the list of rows in the game
                Console.WriteLine(game.Score(row));
                //tells me the score (red and white respectively) for that particular turn
            }

            Console.WriteLine("Out of turns!");
        }
    }
}