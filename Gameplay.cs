using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Crisostomo_GameProject
{
    public static class Gameplay
    {
        public static void MainGamePlay()
        {
            Random random = new Random();
            Console.Clear();

            for (int i = 0; i < Program.enemies.Count; i++)
            {
                IntroduceEnemy(i);
                // Change enemies when another enemy died
                Program.enemyUnit = Program.enemies[i];
                
                while (!Program.playerUnit.IsDead && !Program.IsGameOver)
                {
                    // Player turn
                    PlayerActions();

                    // Check player and enemy condition then break while-loop
                    if (Program.playerUnit.IsDead || Program.enemyUnit.IsDead || Program.IsGameOver)
                    {
                        break;
                    }

                    Console.ReadKey();

                    // Enemy turn
                    Console.WriteLine("\n------------------------------------------------------------");
                    Console.WriteLine($"{Program.playerUnit.unitName}  HP: {Program.playerUnit.HP}  Attack: {Program.playerUnit.AP}  Heal: {Program.playerUnit.HealPR}");
                    Console.WriteLine($"{Program.enemyUnit.unitName}  HP: {Program.enemyUnit.HP}  Attack: {Program.enemyUnit.AP}  Heal: {Program.enemyUnit.HealPR}");
                    Console.WriteLine("------------------------------------------------------------");

                    int enemyChoice = random.Next(0, 3);

                    switch (enemyChoice)
                    {
                        case 0:
                            // Attack logic
                            Program.enemyUnit.Attacking(Program.playerUnit);
                            break;
                        case 1:
                            // Heal logic
                            Program.enemyUnit.Heal();
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine($"{Program.enemyUnit.unitName} have missed their opportunity to take actions");
                            Console.ResetColor();
                            break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                // If the player is dead or gave up to break the for-loop
                if (Program.playerUnit.IsDead || Program.IsGameOver)
                {
                    break;
                }

                // Player status upgrade or Level Up
                Console.WriteLine($"[ {Program.playerUnit.unitName} defeated {Program.enemyUnit.unitName}! ]");
                Program.playerUnit.StatsUP(Program.playerUnit);
                Console.WriteLine($"{Program.playerUnit.unitName}  HP: {Program.playerUnit.HP}+20  Attack: {Program.playerUnit.AP}+4  Heal: {Program.playerUnit.HealPR}+4");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void PlayerActions()
        {
            // Tracking information of the units
            Console.WriteLine("\n------------------------------------------------------------");
            Console.WriteLine($"{Program.playerUnit.unitName}  HP: {Program.playerUnit.HP}  Attack: {Program.playerUnit.AP}  Heal: {Program.playerUnit.HealPR}");
            Console.WriteLine($"{Program.enemyUnit.unitName}  HP: {Program.enemyUnit.HP}  Attack: {Program.enemyUnit.AP}  Heal: {Program.enemyUnit.HealPR}");
            Console.WriteLine("------------------------------------------------------------\n");

            // Action selection window
            Console.WriteLine("            [ Choose action ]             ");
            Console.WriteLine("==========================================");
            Console.WriteLine("||         (a) Attack  (h) Heal         ||");
            Console.WriteLine("||             (g) Give Up              ||");
            Console.WriteLine("==========================================\n");

            // Prompt player action input
            Console.Write("Enter chosen action: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string action = Console.ReadLine()?.ToLower();   //read input and convert to lower case
            Console.ResetColor();

            // Input invalidation
            if (string.IsNullOrEmpty(action) || action.Length != 1)
            {
                Console.WriteLine("Invalid input. Skipped a turn!");
            }

            // Action executions
            switch (action)
            {
                case "a":
                    // Add attack logic here
                    Program.playerUnit.Attacking(Program.enemyUnit);
                    break;
                case "h":
                    // Add heal logic here
                    Program.playerUnit.Heal();
                    break;
                case "g":
                    //giving up logic
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nYou run at the sight of the monster, what a cowardly hero  :)");
                    Console.ResetColor();

                    // Set the game over flag
                    Program.IsGameOver = true;  
                    break;
                default:
                    Console.WriteLine("Invalid input. Skipped a turn!");
                    break;
            }
        }
        public static void IntroduceEnemy(int i)
        {
            if (i == 2)
            {
                // Encounter with the boss monster
                Console.Clear();
       
                Console.WriteLine("You seek a shelter in the abyss like to rest your tired body from multiple battles.");
                Console.WriteLine("You found a caving in the walls. It seems doable a a shelter. You rest your body.");
                Console.WriteLine("Suddenly, you felt shivers, your  senses tells you something dangerous is approaching.");
                Console.WriteLine("A long limb of what seems a leg of a creature first emerged from the darkness.");
                Console.WriteLine("The creature is now standing infront of you. Menacing...");
                Console.ReadKey();

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("  =============================");
                Console.WriteLine("**|| Boss monster appears!!! ||**");
                Console.WriteLine("  =============================");
                Console.ResetColor();
                Console.ReadKey();
            }
            else if (i == 1)
            {
                // Encounter with the second monster
                Console.Clear();
                Console.WriteLine("You walked along the path connected to the chamber where you slain the shadow goblin...");
                Console.WriteLine("You entered a passage way, you felt a presence stalking you.");
                Console.WriteLine("You encountered a [Night Stalker]. Get Ready for combat");
                Console.ReadKey();
            }
            else
            {
                // Encounter with the first monster
                Console.Clear();
                Console.WriteLine("You take your first steps into the unknown...");
                Console.WriteLine("Suddenly, a wild monster appears in front of you!");
                Console.WriteLine("Defeat the [Dark Goblin].");
                Console.WriteLine("\n-------------------------------------------------------------------------------");
                Console.ReadKey();
            }
        }
    }
}