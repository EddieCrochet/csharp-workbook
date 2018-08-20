using System;
using System.Collections.Generic;

namespace TowersOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(new Dictionary<Tower, Block>());
            Tower A = new Tower(new Stack<Block>());
            Tower B = new Tower(new Stack<Block>());
            Tower C = new Tower(new Stack<Block>());

            Console.WriteLine("the build is so far successful");
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
        public Stack<Block> towers = new Stack<Block>();

        public Tower(Stack<Block> Towers)
        {
            this.towers = Towers;

            
        }
    }

    class Game
    {
        public Dictionary<Tower, Block> towerDict = new Dictionary<Tower, Block>();

        public Game(Dictionary<Tower, Block> TowerDict)
        {
            this.towerDict = TowerDict;


        }
    }
}
