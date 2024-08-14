using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;



namespace attack_the_dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Messages
            string message = "You died";
            string message2 = "You slayed the beast in the dungeon, yay!";

            // Player
            string playerName;
            int playerHP = 20;
            int playerDamage = 0;
            int playerTurn = 0;
            int stateffect = 0;
            int turneffect = 0;
            bool playerStatus = true;
            string playerChoice = "";
            int playerRoll = 0;
            string weaponPW = "";
            string weapon = "";
            int weaponturn = 0;

            // Weapons
            int[] mace = { 4, 1, 1 };   // Mace: slow effect (minus 1 enemy turn)
            int[] daggers = { 3, 3 };    // Daggers: more attacks per round
            int[] staff = { 5, 1, 1 };   // Staff: burn effect (1 damage per round)

            // Monster
            int goblinHP = 25;
            int goblinDamage = 2;
            int goblinTurn = 2;
            int goblinStDamage = 2;  // Poison damage

            // Game Start
            Console.WriteLine("What's your name, foolish adventurer?");
            Console.Write("Enter Name: ");
            playerName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"I see you came here without a weapon... I was joking earlier but damn, {playerName}...");
            Console.ReadLine();
            Console.WriteLine("I have 3 extra weapons you can use. Choose one:");
            Console.ReadLine();

            while (playerDamage == 0)
            {
                // Mace Selection
                Console.WriteLine($"Mace! A mighty weapon, one hit with this bad boy and your enemies will be on the floor in no time. It also slows them down (that means your enemies will have one less attack per round, {playerName}).");
                Console.Write($"{playerName}, Yes or No?: ");
                playerChoice = Console.ReadLine().Trim();

                if (playerChoice == "Yes" || playerChoice == "yes")
                {
                    Console.WriteLine("Good choice! I like to smash things myself.");
                    Console.ReadLine();
                    playerDamage = mace[0];
                    playerTurn = mace[1];
                    turneffect = mace[2];
                    weaponPW = "Smash";
                    weapon = "Mace";
                    weaponturn = mace[1];
                    break;
                }

                // Dagger Selection
                Console.WriteLine("No, huh? Mmm... this Dagger then. One attack = 3. What do you say?");
                Console.Write($"{playerName}, Yes or No?: ");
                playerChoice = Console.ReadLine().Trim();

                if (playerChoice == "Yes" || playerChoice == "yes")
                {
                    Console.WriteLine("Like to be sneaky, huh?");
                    Console.ReadLine();
                    playerDamage = daggers[0];
                    playerTurn = daggers[1];
                    stateffect = 0;
                    weaponPW = "Stab";
                    weapon = "Dagger";
                    weaponturn = daggers[1];
                    break;
                }

                // Staff Selection
                Console.WriteLine("Not that either? Ah, you must be more of a staff guy then.");
                Console.WriteLine("It's great! Just shout fireball, and everything will be ablaze.");
                Console.Write($"{playerName}, Yes or No?: ");
                playerChoice = Console.ReadLine().Trim();

                if (playerChoice == "Yes" || playerChoice == "yes")
                {
                    Console.WriteLine("EXPLOSION!! Get it?");
                    Console.ReadLine();
                    playerDamage = staff[0];
                    playerTurn = staff[1];
                    stateffect = staff[2];
                    weaponPW = "Fireball";
                    weapon = "Staff";
                    weaponturn = staff[1];
                    break;
                }

                Console.WriteLine($"...I only have 3 weapons, {playerName}. Now I have to do this again.");
            }

            Console.WriteLine($"All set to go then, good luck, {playerName}! Just head through that door");
            Console.ReadLine();
            Console.Clear();

            // Game Narration
            Console.WriteLine("Narrator: You walk through the door and realize that this isn't even a dungeon, it's basically a cave... a small one.");
            Console.ReadLine();
            Console.WriteLine("Narrator: Roll Perception.");
            Console.ReadLine();
            Console.Write("Enter a Number between 1 & 20: ");
            playerRoll = int.Parse(Console.ReadLine());

            if (playerRoll >= 13)
            {
                Console.WriteLine("Narrator: You notice something shining behind you. As you turn to look, you see a goblin staring at you with a poisonous dagger behind the dungeon door.");
                Console.ReadLine();

                while (playerChoice != weaponPW)
                {
                    Console.WriteLine($"(Surprise round) What do you do!? {weaponPW} or Run away?");
                    playerChoice = Console.ReadLine().Trim();

                    if (playerChoice == weaponPW)
                    {
                        goblinHP -= playerDamage;
                        goblinTurn -= turneffect;
                        int Damage = playerDamage + stateffect;
                        Console.WriteLine($"Goblin HP: {goblinHP}, Player Damage: {Damage}");
                        Console.ReadLine();

                        if (goblinHP <= 0)
                        {
                            MessageBox.Show($"{message2}, Maybe you're not so dumb after all.", "Attack the Dungeon");
                            Environment.Exit(0);
                        }
                        break;
                    }
                    else if (playerChoice == "Run away")
                    {
                        Console.WriteLine("Narrator: Afraid, you run away.");
                        Console.ReadLine();
                        MessageBox.Show($"{message}, Due to cowardice.", "Attack the Dungeon");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Please choose a valid option.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Goblin: {Surprise round} GAAH!");
                Console.ReadLine();
                Console.WriteLine("Narrator: A green goblin jumps on your back. Before you know it, you're stabbed with a small poisonous dagger.");
                Console.ReadLine();
                playerHP -= (goblinDamage + 3);

                if (playerHP <= 0)
                {
                    MessageBox.Show($"{message}, HAHA, stupid.", "Attack the Dungeon");
                    Environment.Exit(0);
                }
            }

            Console.WriteLine("Objective: Survive");

            // Main Combat Loop
            while (playerStatus)
            {
                // Player Turn
                while (playerTurn > 0)
                {
                    Console.Write($"What do you do!? {weaponPW} or Run Away? ");
                    playerChoice = Console.ReadLine().Trim();

                    if (playerChoice == weaponPW)
                    {
                        goblinHP -= (playerDamage + stateffect);
                        int Damage = playerDamage + stateffect;
                        goblinTurn -= turneffect;
                        Console.WriteLine($"Goblin HP: {goblinHP}, Player Damage: {Damage}");
                        Console.ReadLine();

                        if (goblinHP <= 0)
                        {
                            MessageBox.Show($"{message2}, Maybe you're not so dumb after all.", "Attack the Dungeon");
                            Environment.Exit(0);
                        }
                    }
                    else if (playerChoice == "Run away")
                    {
                        Console.WriteLine("Narrator: Afraid, you run away.");
                        Console.ReadLine();
                        MessageBox.Show($"{message}, Due to cowardice.", "Attack the Dungeon");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Please choose a valid option.");
                    }

                    playerTurn--;
                }

                playerTurn = weaponturn;  // Reset player turn

                // Goblin Turn
                while (goblinTurn > 0)
                {
                    Console.WriteLine("Goblin: Hehehe GAAAH");
                    playerHP -= (goblinDamage + goblinStDamage);
                    int gbDamage = goblinDamage + goblinStDamage;
                    Console.WriteLine($"Player HP: {playerHP}, Goblin Damage: {gbDamage}");

                    if (playerHP <= 0)
                    {
                        playerStatus = false;
                        MessageBox.Show($"{message}, HAHA, stupid.", "Attack the Dungeon");
                        Environment.Exit(0);
                    }

                    goblinTurn--;
                }

                goblinTurn = 2;  // Reset goblin turn
            }

            Console.ReadLine();
        }
    }
}
