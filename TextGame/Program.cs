using System;

namespace TextGame
{
    class Program
    {
        static void Main(string[] args)
        {

            string ch1 = System.String.Empty;
            string ch2 = System.String.Empty;           //assigning variables
            string ch3 = System.String.Empty;
            string LpGm = System.String.Empty;
            int stick = 0;
            int complete = 0;
            string lpGm = System.String.Empty;
            bool alive = true;
            while (alive == true)
            {



                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Welcome to the cavern of secrets!");     //intro to the game
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");


                System.Threading.Thread.Sleep(3000); //time.sleep(3) ... the game waits a bit

                Console.WriteLine("You enter a dark cavern out of curiosity. It is dark and you can only make out a small stick on the floor.");
                Console.WriteLine("Do you take it?? [y/n]");
                ch1 = Console.ReadLine();

                //if the stick is taken
                if (ch1 == "y")
                {
                    Console.WriteLine("You have taken the stick!");
                    System.Threading.Thread.Sleep(2000); 
                    stick = 1;
                }
                else
                {      //if the stick is not taken
                    Console.WriteLine("You did not take the stick");
                    stick = 0;
                }

                //continuing on with our adventure
                Console.WriteLine("As you proceed further into the cave, you see a small glowing object");
                Console.WriteLine("Do you approach the object? [y/n]");
                ch2 = Console.ReadLine();

                if (ch2 == "y")
                {        //APPROACH SPIDER
                    Console.WriteLine("You approach the object...");
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("As you draw closer, you begin to make out the object as an eye!");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("The eye belongs to a giant spider!");
                    Console.WriteLine("Do you try to fight it? [Y/N]");
                    ch3 = Console.ReadLine();
                    if (ch3 == "y"){     //IF YOU DECIDE TO FIGHT THE SPIDER
                        if (stick == 1){        //FIGHT SPIDER AND HAVE A STICK
                            Console.WriteLine("You only have a stick to fight with!");
                            Console.WriteLine("You quickly jab the spider in it's eye and gain an advantage!");
                            System.Threading.Thread.Sleep(2000);
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("                  Fighting...                   ");
                            Console.WriteLine("   YOU MUST HIT ABOVE A 5 TO KILL THE SPIDER    ");
                            Console.WriteLine("IF THE SPIDER HITS HIGHER THAN YOU, YOU WILL DIE");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            System.Threading.Thread.Sleep(2000);
                            Random rng = new Random();
                            int playerDmg = rng.Next(3, 10);
                            int spiderDmg = rng.Next(1, 5);
                            Console.WriteLine("Your hit does " + playerDmg + " damage!");
                            Console.WriteLine("The spiders hit does " + spiderDmg + " damage!");
                            System.Threading.Thread.Sleep(2000);
                                if (spiderDmg > playerDmg){     //IF SPIDER DEALS MORE DAMAGE THAN YOU
                                    Console.WriteLine("The spider has dealt more damage than you!");
                                    System.Threading.Thread.Sleep(1000);
                                    complete = 0;
                                }else if (playerDmg < 5){       //NOT ENOUGH DMG TO KILL SPIDER BUT SURVIVED BATTLE
                                    Console.WriteLine("You didn't kill the spider but you manage to escape.");
                                    complete = 1;
                                }else{          //BEAT THE SPIDER IN BATTLE
                                    Console.WriteLine("You killed the spider!"); 
                                    complete = 1;    
                                }
                        }else if (stick == 0){          //FIGHT SPIDER AND HAVE NO STICK
                            Console.WriteLine("You don't have anything to fight with!");
                            System.Threading.Thread.Sleep(2000);
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("                  Fighting...                   ");
                            Console.WriteLine("   YOU MUST HIT ABOVE A 5 TO KILL THE SPIDER    ");
                            Console.WriteLine("IF THE SPIDER HITS HIGHER THAN YOU, YOU WILL DIE");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            System.Threading.Thread.Sleep(2000);
                            Random ran = new Random();
                            int playerDam = ran.Next(1, 8);
                            int spiderDam = ran.Next(1, 5);
                            Console.WriteLine("Your hit does " + playerDam + " damage!");
                            Console.WriteLine("The spiders hit does " + spiderDam + " damage!");
                            System.Threading.Thread.Sleep(2000);
                            if (spiderDam > playerDam){     //IF SPIDER DEALS MORE DAMAGE THAN YOU
                                Console.WriteLine("The spider has dealt more damage than you!");
                                complete = 0;
                            }else if (playerDam < 5){       //NOT ENOUGH TO KILL THE SPIDER BUT SURVIVED BATTLE
                                Console.WriteLine("You didn't kill the spider but you managed to escape");
                                complete = 1;
                            }else{           //KILLED TH SPIDER IN BATTLE
                                Console.WriteLine("You killed the spider!");
                                complete = 1;
                            }
                        }
                    }else{      //DECIDE NOT TO FIGHT THE SPIDER
                        Console.WriteLine("You choose not to fight the spider...");
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine("As you turn away, it ambushes you and impales you with it's fangs!!!");
                        complete = 0;
                    }
                }else{  //DO NOT APPROACH SPIDER
                    Console.WriteLine("You turn away from the glowing object, and attempt to leave the cave...");
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("But something won't let you....");
                    System.Threading.Thread.Sleep(2);
                    complete = 0;
                }
                    
            //GAME LOOP
                            if (complete == 1)
                            {
                                Console.WriteLine("You managed to escape the cavern alive! Would you like to play again? [y/n]:");
                                alive = Convert.ToBoolean(Console.ReadLine());
                                if (LpGm == "y")
                                { //IF YOU CHOSE TO PLAY AGAIN IT LOOPS THE MAIN GAME BACK TO THE START
                    
                                }
                            }
                        }
        }
    }
}
