using System;
using System.Collections.Generic;

namespace TowersOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            int numBlocks = GameBlocks();

            Game game = new Game(numBlocks);
            //starts our new game up with our numBlocks in that runs our first method, GameBlocks
            Block[] blocks = new Block[game.Blocknum];
            //makes array of the class of Block all with individual ints called game.Blocknum

            for (int i = game.Blocknum - 1; i >= 0; --i)
            //loops through all balls in turn and assigns a consecutive number to each
            {
                blocks[i] = new Block(i+1);
                game.towers["A"].blockstack.Push(blocks[i]);
                //adds all balls in the game to start on Tower A
            }
            
            game.ShowBoard();
            //shows our board for the first time

            bool won = false;
            //a boolean to match against the checkWin method
            while (!won)
            //if we haven't won yet
            {
                //keep the game play happening here until a win is found
                game.AskMove();
                game.ShowBoard();
                won = game.CheckWin();
            }

            Console.WriteLine("You win!");
        }

        public static int GameBlocks()
        //method to set the number of blocks in the game
        {
            Console.WriteLine("How many blocks do you want to play with?");
            string input = Console.ReadLine();
            //reads the user's input as a string
            int numBlocks;
            bool result = Int32.TryParse(input, out numBlocks);
            //attempt to convert user input from string to int
            if (!result)
            //if it cant be converted
            {
                Console.WriteLine("You need to pick a number of blocks.");
                //restate the input we need and run the function again until we can return an int
                numBlocks = GameBlocks();
            }
            return numBlocks;
        }
    }
    class Block
    {
        public int weight {get; private set;}

        public Block(int Weight)
        {
            this.weight = Weight;
        }
    }

    class Tower
    {
        public Stack<Block> blockstack = new Stack<Block>();
        //stack of blocks in the towers class
        //empty shell until filled

        public Tower(Stack<Block> BlockStack)
        {
            this.blockstack = BlockStack;
        }
    }

    class Game
    {
        public Dictionary<string, Tower> towers = new Dictionary<string, Tower>();
        //dictionary of towers - string (A, B, C) and the Tower Class

        public int Blocknum = 0;

        public Game(int blocknum)
        //blocknum is what the user will set to be the nuber of blocks in the game
        {
            towers.Add("A", new Tower(new Stack<Block>()));
            towers.Add("B", new Tower(new Stack<Block>()));
            towers.Add("C", new Tower(new Stack<Block>()));

            Blocknum = blocknum;
        }

        public void ShowBoard()
        {
            foreach (KeyValuePair<string, Tower> tower in this.towers)
            //selects each key value pair in our dictionary of towers
            {
                Console.WriteLine("Tower {0} contains:", tower.Key);

                foreach(Block block in tower.Value.blockstack)
                {
                    Console.WriteLine(block.weight);
                    //writes out the weight of each block in the stack for each tower
                }
                Console.WriteLine();
            }
        }

        public void AskMove()
        //method that plays out for each turn in the game
        {
            try
            //used this try/catch to handle the exceptions of an invalid entry
            {
                Console.WriteLine("Which tower do you want to move from? (A,B,C)");
                string from = Console.ReadLine().ToUpper();
                Console.WriteLine("Where would you like to place it (A,B,C)");
                string to = Console.ReadLine().ToUpper();

                MovePiece(towers[from], towers[to]);
                //this calls our method that actually moves the pieces
            }
            catch
            {
                Console.WriteLine("Please enter a valid move.");
                AskMove();
            }
        }

        public void MovePiece(Tower from, Tower to)
        {
            if (!IsLegal(from, to))
            //if it is not a legal move the program will let them know
            {
                Console.WriteLine("That is not a legal move!");
                Console.WriteLine("");
                //and loop back to the askmove function
                AskMove();
            }
            else
            {
                Block tomove = from.blockstack.Pop();
                //we pop off the block into a variable and push it back onto another stack
                to.blockstack.Push(tomove);
            }
        }

        public bool IsLegal(Tower from, Tower to)
        //method to actually check legality of block move (weight)
        {
            if (to.blockstack.Count <= 0)
                return true;

            if (from.blockstack.Count <= 0)
            {
                Console.WriteLine("There is nothing to move from that Tower.");
                return false;
            }

            Block popoff = from.blockstack.Peek();
            //looks at the values before we try and move to compare the weights
            Block pushon = to.blockstack.Peek();

            if (pushon == null)
                return true;
            else if (popoff.weight < pushon.weight)
                return true;
            else
                return false;
        }
        public bool CheckWin()
        {
            if (towers["A"].blockstack.Count == 0 && towers["B"].blockstack.Count == 0)
            //if towers A and B are empty you have won the game!
                return true;
            else
                return false;
        }
    }
}
