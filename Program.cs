using System;
namespace Crisostomo_GameProject
{
    public class Program
    {
        // Create instances
        public static Unit playerUnit;
        public static Unit enemyUnit;
        public static List<Unit> enemies;
        public static bool IsGameOver = false;       // Set game over
        static void Main(string[] args)
        {

            StartGameUp();

            ActiveEnemyName();

            //Gameplay logic here
            Gameplay.MainGamePlay();

            DisplayEndingScreen();
        }
        static void StartGameUp()   // Start of the game method
        {
            // Title screen
            Console.WriteLine("*******************************************************************************");
            Console.WriteLine("**                                                                           **");
            Console.WriteLine("**                            *** ROUGE SOULS ***                            **");
            Console.WriteLine("**                                                                           **");
            Console.WriteLine("*******************************************************************************");
            Console.WriteLine("                              >>>Press any key<<<                              ");
            Console.ReadKey();
            Console.Clear();

            // Introduction narrative
            Console.WriteLine("\nYou have awakened from your slumber in a dark, cold dungeon.");
            Console.WriteLine("Your mind is foggy, but you must remember... do you recall your name?");
            Console.WriteLine();

            // Prompt for player's name
            Console.Write("Unknown voice: \"I think my name is... ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            string playerName = Console.ReadLine();
            Console.ResetColor();

            // Initialize the player Unit
            playerUnit = new Unit(50, 8, 6, playerName);

            Console.Clear();
            Console.WriteLine("********************************************************************************************");
            Console.WriteLine($"\n{playerName}, you find yourself alone in the abyss, surrounded by darkness.");
            Console.WriteLine("You must climb your way to the surface to survive, facing countless monsters along the way.");
            Console.WriteLine("With each battle, you will grow stronger and gain new powers.");
            Console.WriteLine("\nYour journey begins now. Prepare yourself for the challenges ahead.");
            Console.WriteLine("\n******************************************************************************************");

            // Prompt to start the game
            Console.WriteLine("\nPress any key to start your journey...");
            Console.ReadKey();
        }
        static List<Unit> EnemyGenerator()
        {
            // Initialize list of enemy units
            var enemyList = new List<Unit>();

            enemyList.Add(new Unit(50, 7, 6, "Shadow Goblin"));
            enemyList.Add(new Unit(80, 13, 10, "Night Stalker"));
            enemyList.Add(new Unit(95, 20, 16, "Navarro, The Tall One"));

            return enemyList;
        }
        static void ActiveEnemyName()
        {
            enemies = EnemyGenerator();
        }
        public static void DisplayEndingScreen()
        {
            if (playerUnit.IsDead)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("**                                                                           **");
                Console.WriteLine("**                               GAME OVER!                                  **");
                Console.WriteLine("**                                                                           **");
                Console.WriteLine("*******************************************************************************");
                Console.ResetColor();

                Console.ReadKey();

                Console.WriteLine("What a shame. Your struggle to survive was left in vain as your flesh rots at the end of the abyss...");
            }
            else if (Program.IsGameOver)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[ Game Over ]");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("**                                                                           **");
                Console.WriteLine("**                            YOU ARE VICTORIOUS!                            **");
                Console.WriteLine("**                                                                           **");
                Console.WriteLine("*******************************************************************************");

                Console.WriteLine($"As the last monster falls, you stand victorious, {playerUnit.unitName}, a survivor of the abyss.");
                Console.WriteLine("Yet, in the distance, a shadow looms. You sense that this is only the beginning.");
                Console.WriteLine("Greater challenges and darker foes await. Your journey is far from over.");

                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Thank you for playing the game...  - J.C");
            }
        }
    }
}
