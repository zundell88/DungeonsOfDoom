using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;



namespace DungeonsOfDoom.Core
{
    class AlternativeGamePresenter : IGamePresenter
    {        
        public void DisplayPlayerInfo(Player player, string lastStatusEnemy, string lastStatusItem)
        {
            string name = "AlbinoSlayer";
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            GamePrints.PrintBanner();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            if (player.Health < 10)
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
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            if (player.Health < 10)
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
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"        Name: {name}");
            if (player.Health < 20)
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
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
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
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"         Strenght: {player.Strength}");
            if (player.Health < 70)
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
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"        Armor: {player.Armor}");
            Console.WriteLine($"                              Enemies left: {Enemy.EnemyCount}");
            if (player.Health < 90)
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
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"       Position: {player.X}.{player.Y}");
            Console.WriteLine($"                         Enemies killed: { Enemy.KilledEnemyCount}");
            Console.WriteLine($"                     Items: [L: {player.LeftHandItems.Count}/1] [R: {player.RightHandItems.Count}/1]\n");            
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
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            CenterText.WriteCenterLine("Use [" + (char)27 + " " + (char)26 + " " + (char)24 + " " + (char)25 + "] to move, [SPACE] to pick up, [I] to check inventories, [Q] for FAQ.");            
            Console.ForegroundColor = ConsoleColor.Black;
            CenterText.WriteCenterLine(@"___________________________________________________________");            
        }
        public void DisplayWorld(Player player, Room[,] rooms)
        {
            int worldWidth = rooms.GetLength(0);
            int worldHeight = rooms.GetLength(1);

            for (int y = 0; y < worldHeight; y++)
            {                
                Console.ForegroundColor = ConsoleColor.Black;
                CenterText.WriteCenterLine("|     |     |     |     |     |     |     |     |     |     |");
                Console.Write("                 |");
                for (int x = 0; x < worldWidth; x++)
                {
                    if (y == player.Y && x == player.X)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write("  ");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write((char)2);
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("  |");
                    }
                    else if (rooms[x, y].Item != null)
                    {
                        Item item = rooms[x, y].Item;
                        if (item is Weapon)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("  ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(item.Symbole);
                            Console.ResetColor();
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("  |");
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("  ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(item.Symbole);
                            Console.ResetColor();
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("  |");
                        }
                    }
                    else if (rooms[x, y].Enemy != null)
                    {
                        Enemy enemy = rooms[x, y].Enemy;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("  ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        
                        Console.Write(enemy.Symbole);
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("  |");
                    }
                    else if (rooms[x, y].Boss != null)
                    {
                        Boss boss = rooms[x, y].Boss;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("  ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(boss.Symbole);
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("  |");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("     |");
                    }
                }                
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("");                
                CenterText.WriteCenterLine("|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|");                
            }
        }
        public void StartMeny()
        {
            GamePrints.PrintBanner();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine();
            CenterText.WriteCenterLine("WELCOME TO DUNGEONS OF DOOM!");
            CenterText.WriteCenterLine("This is a dungeon crawl -based game where you take the role of a monster.");
            CenterText.WriteCenterLine("Your goal is to kill all living creatures that come in your way.");
            CenterText.WriteCenterLine("To help, you will find weapons and health throughout the gamefield.\n");
        }
        public void LevelComplete()
        {
            Console.Clear();
            Console.ResetColor();
            GamePrints.PrintGameOver();
            CenterText.WriteCenterLine("Press a key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public void GameOver()
        {
            Console.Clear();            
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
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            GamePrints.PrintInventory(player);
            Console.ReadKey();
            Console.Clear();
        }
        public void DisplayFaq()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            GamePrints.PrintFaq();
            Console.ReadKey();
            Console.Clear();
        }
        public void QuitGame()
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to Quit? [y/n]");
            string answer = Console.ReadLine().ToLower();
            if (answer == "y")
            {
                System.Environment.Exit(0);
            }
            else
                Console.Clear();
        }
        public bool AskPlayAgain()
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.White;
            CenterText.WriteCenter("Give it another try? [N/Y] ");
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

