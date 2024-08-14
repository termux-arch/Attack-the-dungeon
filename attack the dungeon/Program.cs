using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace attack_the_dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = "you died";
            string message2 = "You slayed the beast in the dungeon yay";
            int Damage = 0;
            int i = 0;
            int gbDamage = 0;

            //Player
            string playerName;
            int playerHP = 20;
            int playerDamage = 0;
            int playerTurn = 0;
            int stateffect = 0;
            int turneffect = 0;
            bool playerStatus = true;
            string playerChoice = "";
            int playerRoll = 0;
            string[] statusEff = { "poison", "burn", "slow" };

            //Weapons
            int[] mace = { 3, 1, 1 };//slow minus 1 turn
            int[] daggers = { 2, 3 };//does nothing but has more turns
            int[] staff = { 2, 1, 1 }; //burns for 1 damage each round
            string weaponPW = "";
            string weapon = "";
            int weaponturn = 0;

            //Monster
            
            int goblinHP = 25;
            int goblinDamage = 2;
            int goblinTurn = 2;
            int goblinStDamage = 2; //poison damage
            


            Console.WriteLine("Whats your name foolish adventurer?");
            Console.Write("Enter Name_ ");
            playerName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("I see you came here without a weapon... I was joking earlier but damn {0}...", playerName);
            Console.WriteLine("I have 3 extra weapons you can use choose one");

            while (playerDamage == 0)
            {
                Console.WriteLine("Mace! A mighty weapon, one hit with this bad boy and your enimies will be on the floor in no time it also slows them down (that means your enimies will have one less attack per round {0})", playerName);
                Console.Write("{0} Yes or No?: ", playerName);
                playerChoice = Console.ReadLine();

                while (playerChoice != "Yes" || playerChoice != "No")
                {
                    Console.WriteLine("What, Can you read?");
                    Console.Write("{0} Yes or No?: ", playerName);
                    playerChoice = Console.ReadLine();

                    if (playerChoice == "No")
                    {
                        Console.WriteLine("You poor thing");
                    }
                    else
                    {
                        Console.WriteLine("I knew you where dumb, Just type Yes or No you dumb biscuit");

                        break;
                    }

                }



                if (playerChoice == "Yes")
                {
                    Console.WriteLine("Good choice i like to smash things myself");
                    playerDamage = mace[0];
                    playerTurn = mace[1];
                    turneffect = mace[2];
                    weaponPW = "Smash";
                    weapon = "Mace";
                    weaponturn = mace[1];
                    break;
                }

                Console.WriteLine("No huh mmm... this Dagger then one attack = 3 what do you say?");
                Console.Write("{0} Yes or No?: ", playerName);
                playerChoice = Console.ReadLine();

                if (playerChoice == "Yes" || playerChoice == "yes")
                {
                    Console.WriteLine("Like to be sneaky huh");
                    playerDamage = daggers[0];
                    playerTurn = daggers[1];
                    stateffect = 0;
                    weaponPW = "Stab";
                    weapon = "Dagger";
                    weaponturn = daggers[1];
                    break;
                }

                Console.WriteLine("Not that either? AA you must be more of a staff guy then");
                Console.WriteLine("Its great just shout fireball and everything will be ablaze");
                Console.Write("{0} Yes or No?: ", playerName);
                playerChoice = Console.ReadLine();

                if (playerChoice == "Yes" || playerChoice == "yes")
                {
                    Console.WriteLine("EXPLOSION!! get it?");
                    playerDamage = staff[0];
                    playerTurn = staff[1];
                    stateffect = staff[2];
                    weaponPW = "Fireball";
                    weapon = "Staff";
                    weaponturn = staff[1];
                    break;
                }
                else if (playerChoice == "No" || playerChoice == "no")
                {
                    Console.WriteLine("...i only have 3 weapons {0} aa now i have to do this againn", playerName);
                }


            }

            Console.WriteLine("All set to go then, goodluck {0}", playerName);
            Console.Clear();

            Console.WriteLine("Narrator: you walk through the door and you realize that this isn't even a dungeon its basically a cave... a small one");
            Console.WriteLine("Narrator: Roll Perception ");

            Console.Write("{Enter a Number between 1 & 20}: ");
            playerRoll = int.Parse(Console.ReadLine());

            if (playerRoll >= 13)
            {
                Console.WriteLine("Narrator: you notice something shining behind you. As you turn to Look what it is you notice a goblin staring at you with a posioness dagger behind the dungeon door");

                while (playerChoice != "Run away")
                {
                    Console.WriteLine("{Suprise round} What Do you do!? {0} or Run away!?", weaponPW);
                    playerChoice = Console.ReadLine();

                    if (playerChoice == weaponPW)
                    {
                        goblinHP = goblinHP - playerDamage;
                        goblinTurn = goblinTurn - turneffect;
                        if (goblinHP <= 0)
                        {
                            MessageBox.Show(message2 + ",Maybe you're not so dumb afterall", "Attack the Dungeon");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Narrator: Afraid you run away");
                        Console.Write("");
                        Console.ReadLine();
                        MessageBox.Show(message + " ,Due to cowardness", "Attack the Dungeon");
                        Environment.Exit(0);

                    }

                }

            }
            else
            {
                Console.WriteLine("Goblin:{Suprise round} GAAH!");
                Console.WriteLine("Narrator: A Green goblin jumps on you back before you know it you're stabbed with a small posioness dagger");
                playerHP = playerHP - (goblinDamage + 3);
                if (playerHP <= 0)
                {
                    MessageBox.Show(message + ",HAHA stupid", "Attack the dungeon");
                    Environment.Exit(0);
                }

            }

            Console.WriteLine("Narrator: Goodluck!");

            while (playerStatus == true)
            {
                while (playerTurn != 0)
                {
                    Console.Write("What do you do!? {0} or Run Away?", weaponPW);
                    playerChoice = Console.ReadLine();

                    if (playerChoice == weaponPW)
                    {
                        goblinHP = goblinHP - (playerDamage + stateffect);
                        Damage = playerDamage + stateffect;
                        goblinTurn = goblinTurn - turneffect;
                        Console.WriteLine($"Goblin HP:{goblinHP}, Player Damage:{Damage}");
                        if (goblinHP <= 0)
                        {
                            MessageBox.Show(message2 + ",Maybe you're not so dumb afterall", "Attack the Dungeon");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Narrator: Afraid you run away");
                        Console.Write("");
                        Console.ReadLine();
                        MessageBox.Show(message + " ,Due to cowardness", "Attack the Dungeon");
                        Environment.Exit(0);

                    }
                    playerTurn--;

                }
                playerTurn = weaponturn; //resets turn

                while (goblinTurn != 0)
                {
                    Console.WriteLine("Goblin: Hehehe GAAAH");
                    playerHP = playerHP - (goblinDamage + goblinStDamage);
                    gbDamage = goblinDamage + goblinStDamage;
                    Console.WriteLine($"Player HP:{playerHP}, Goblin Damage:{gbDamage}");
                    if (playerHP <= 0)
                    {
                        playerStatus = false;
                        MessageBox.Show(message + ",HAHA stupid", "Attack the dungeon");
                        Environment.Exit(0);
                    }
                    goblinTurn--;
                }
                goblinTurn = 2;
            }
            
            
            Console.ReadLine();
        }
    }
}
