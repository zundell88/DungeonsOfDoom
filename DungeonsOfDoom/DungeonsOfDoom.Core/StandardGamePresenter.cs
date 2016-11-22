using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;


namespace DungeonsOfDoom.Core
{
    class StandardGamePresenter : IGamePresenter
    {        
        public void DisplayPlayerInfo(Player player, string lastStatusEnemy, string lastStatusItem)
        {
            
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;   
            GamePrints.PrintBanner();
            if (player.Health < 90)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"        (,,,)");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@"        (,,,)");
                Console.ResetColor();
            }
            if (player.Health < 90)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(@"        (*_+)");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(@"        (*_+)");
                Console.ResetColor();
            }
            Console.WriteLine($"        Name: {player.Name}");
            if (player.Health < 70)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(@"     O===( )===O");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(@"     O===( )===O");
                Console.ResetColor();
            }
            Console.WriteLine($"     Health: {player.Health}");
            if (player.Health < 50)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(@"         | |");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(@"         | |");
                Console.ResetColor();
            }
            Console.WriteLine($"         Strenght: {player.Strength}");
            if (player.Health < 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(@"        // \\");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(@"        // \\");
                Console.ResetColor();
            }
            Console.Write($"        Armor: {player.Armor}");
            Console.WriteLine($"                              Enemies left: {Enemy.EnemyCount}");
            if (player.Health < 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(@"       </   \>");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(@"       </   \>");
                Console.ResetColor();
            }
            Console.Write($"       Position: {player.X}.{player.Y}");
            Console.WriteLine($"                         Enemies killed: { Enemy.KilledEnemyCount}");
            Console.WriteLine($"                     Items: [L: {player.LeftHandItems.Count}/1] [R: {player.RightHandItems.Count}/1]" + Environment.NewLine);           
            if (lastStatusEnemy == null && lastStatusItem == null)
            {
                Console.WriteLine();
            }
            else if (lastStatusItem != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                CenterText.WriteCenterLine(lastStatusItem);
                Console.ResetColor();
            }
            else if (lastStatusEnemy != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                CenterText.WriteCenterLine(lastStatusEnemy);
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            CenterText.WriteCenterLine("Use [" + (char)27 + " " + (char)26 + " " + (char)24 + " " + (char)25 + "] to move, [SPACE] to pick up, [I] to check inventories, [Q] for FAQ.");
            Console.ResetColor();
            CenterText.WriteCenterLine(@"___________________________________________________________");
        }
        public void DisplayWorld(Player player, Room[,] rooms)
        {
            int worldWidth = rooms.GetLength(0);
            int worldHeight = rooms.GetLength(1);

            for (int y = 0; y < worldHeight; y++)
            {
                CenterText.WriteCenterLine("|     |     |     |     |     |     |     |     |     |     |");
                Console.Write("                 |");

                for (int x = 0; x < worldWidth; x++)
                {
                    if (y == player.Y && x == player.X)
                    {

                        Console.Write("  ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(player.Symbole);
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if (rooms[x, y].Item != null)
                    {
                        Item item = rooms[x, y].Item;
                        if (item is Weapon)
                        {
                            Console.Write("  ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(item.Symbole);
                            Console.ResetColor();
                            Console.Write("  |");
                        }
                        else
                        {
                            Console.Write("  ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(item.Symbole);
                            Console.ResetColor();
                            Console.Write("  |");
                        }
                    }
                    else if (rooms[x, y].Enemy != null)
                    {
                        Enemy enemy = rooms[x, y].Enemy;
                        Console.Write("  ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(enemy.Symbole);
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else if (rooms[x, y].Boss != null)
                    {
                        Boss boss = rooms[x, y].Boss;
                        Console.Write("  ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(boss.Symbole);
                        Console.ResetColor();
                        Console.Write("  |");
                    }
                    else
                    {
                        Console.Write("     |");
                    }
                }
                Console.WriteLine("");
                CenterText.WriteCenterLine("|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|");
            }
        }
        public void StartMeny()
        {
            GamePrints.PrintBanner();
            Console.WriteLine();
            CenterText.WriteCenterLine("WELCOME TO DUNGEONS OF DOOM!");
            CenterText.WriteCenterLine("This is a dungeon crawl -based game where you take the role of a monster.");
            CenterText.WriteCenterLine("Your goal is to kill all living creatures that come in your way.");
            CenterText.WriteCenterLine("To help, you will find weapons and health throughout the gamefield." + Environment.NewLine);
        }
        public void LevelComplete()
        {
            Console.ResetColor();
            Console.WriteLine(Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Red;
            GamePrints.PrintLevelComplete();
            CenterText.WriteCenter("Press a key to continue");
            Console.Read();
            Console.Clear();
            
        }
        public void GameOver()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            GamePrints.PrintGameOver();
            Console.ResetColor();            
        }
        public void ShowStory()
        {
            Console.Clear();
            GamePrints.PrintGameStory();            
            Console.Clear();
        }
        public void CheckInventory(Player player)
        {
            Console.Clear();
            GamePrints.PrintInventory(player);           
            Console.ReadKey();
            Console.Clear();
        }

        public void DisplayFaq()
        {
            Console.Clear();
            GamePrints.PrintFaq();
            Console.ReadKey();
            Console.Clear();
        }
        public void QuitGame()
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to Quit? [Y/N]" + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine );
            string answer = Console.ReadLine().ToUpper();
            if (answer == "Y")
            {
                System.Environment.Exit(0);
            }
            else
                Console.Clear();
        }
        public bool AskPlayAgain()
        {
            CenterText.WriteCenter("Try again? [N/Y] ");
            string input = Console.ReadLine().ToUpper();
            bool answer = true;
            switch (input)
            {
                case "Y":
                case "YES":
                    answer = true;
                    break;
                case "N":
                case "NO":
                    answer = false;
                    break;
            }
            return answer;
        }
    }
}
