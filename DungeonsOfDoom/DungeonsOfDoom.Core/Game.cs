using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Utils;

namespace DungeonsOfDoom.Core
{    
    public class Game
    {        
        const int worldWidth = 10; 
        const int worldHeight = 10; 
        string lastStatusEnemy = null;
        string lastStatusItem = null;        
        bool keepPlaying = true;
        static Room[,] rooms;        
        static Player player;
        List<Item> expiredItems = new List<Item>();
        StandardGamePresenter SGP = new StandardGamePresenter();
        AlternativeGamePresenter AGP = new AlternativeGamePresenter();

        public void Start()
        {
            
            while (keepPlaying)
            {               
                    CreateRooms();
                    SGP.StartMeny();
                    CreatePlayer();
                    SGP.ShowStory();

                do
                {                                                   
                    SGP.DisplayPlayerInfo(player, lastStatusEnemy, lastStatusItem);
                    SGP.DisplayWorld(player, rooms);
                    AskForCommand(Console.ReadKey().Key);
                    
                } while (player.Health >= 0 && Enemy.EnemyCount > 0);
               
                if (Enemy.EnemyCount == 0)
                {
                    Console.Clear();
                    SGP.LevelComplete();                                                      
                    Console.Clear();
                    CreateRooms();
                }
                Enemy.PlayerDies(player);
                SGP.GameOver();
                keepPlaying = SGP.AskPlayAgain();
                Console.Clear();
            }            
        }
        private void CreatePlayer()
        {
            string playerName = Player.GetPlayerName();            
            player = new Player(playerName, 100, worldHeight, worldWidth, 1, 1, (char)2);            
        }
        private void RemoveItems()
        {
            foreach (var item in player.LeftHandItems)
            {
                item.Duration--;
                if (item.Duration == 0)
                {
                    player.Strength -= item.Strength;
                    expiredItems.Add(item);
                }
            }
            foreach (var item in player.RightHandItems)
            {
                item.Duration--;
                if (item.Duration == 0)
                {
                    player.Strength -= item.Strength;
                    expiredItems.Add(item);
                }
            }
            foreach (var item in expiredItems)
            {
                
                player.LeftHandItems.Remove(item);
                player.RightHandItems.Remove(item);
            }
        }
        public void AskForCommand(ConsoleKey keyPress)
        {
            if (keyPress == ConsoleKey.LeftArrow)
            {
                RemoveItems();
                player.X--;
                Console.Clear();
                player.Health--;
            }
            else if (keyPress == ConsoleKey.RightArrow)
            {
                RemoveItems();
                player.X++;
                Console.Clear();
                player.Health--;
            }
            else if (keyPress == ConsoleKey.UpArrow)
            {
                RemoveItems();
                player.Y--;
                Console.Clear();
                player.Health--;
            }
            else if (keyPress == ConsoleKey.DownArrow)
            {
                RemoveItems();
                player.Y++;
                Console.Clear();
                player.Health--;
            }
            else
            {
                Console.Clear();
            }
            //Player meets monster
            if (rooms[player.X, player.Y].Enemy != null)
            {
                player.Health++;
                Enemy enemy = rooms[player.X, player.Y].Enemy;
                lastStatusEnemy = $"You wounded a {enemy.Name} with a strength of: {player.Strength} and took: {enemy.Strength} in damage";

                player.Fight(enemy);
                enemy.Fight(player);

                //Player kills monster, 
                if (enemy.Health <= 0)
                {
                    player.Stomach.Add(rooms[player.X, player.Y].Enemy);
                    player.Strength++;
                    rooms[player.X, player.Y].Enemy = null;
                    lastStatusEnemy = $" You killed a {enemy.Name} !!";
                }
            }
            else
                lastStatusEnemy = null;

            if (Enemy.EnemyCount == 0)
            {
                Boss boss = rooms[player.X, player.Y].Boss;
                rooms[0, 0].Boss = new Boss("Anti-Monster Hunter", 1, worldWidth, worldHeight, 50, (char)219);
            }
            if (rooms[player.X, player.Y].Boss != null)
            {
                player.Health++;
                Boss boss = rooms[player.X, player.Y].Boss;
                lastStatusEnemy = $"You wounded a {boss.Name} with a strength of: {player.Strength} and took: {boss.Strength} in damage";
                player.Fight(boss);
                boss.Fight(player);
                if (boss.Health <= 0)
                {
                    player.Stomach.Add(rooms[player.X, player.Y].Boss);
                    player.Health += 50;
                    player.Strength += 10;
                    rooms[player.X, player.Y].Boss = null;
                }
            }
            if (rooms[player.X, player.Y].Item != null)
            {
                if (keyPress == ConsoleKey.Spacebar)
                {
                    Item item = rooms[player.X, player.Y].Item;

                    if (item is Weapon)
                    {
                        if (player.LeftHandItems.Count <= 0)
                        {
                            player.LeftHandItems.Add(item);
                            lastStatusItem = $"You picked up a {item.Name}, your strength increased with {item.Strength}";
                            rooms[player.X, player.Y].Item = null;
                            player.Strength += item.Strength;
                        }
                        else if (player.LeftHandItems.Count > 0 && player.RightHandItems.Count <= 0)
                        {
                            player.RightHandItems.Add(item);
                            lastStatusItem = $"You picked up a {item.Name}, your strength increased with {item.Strength}";
                            rooms[player.X, player.Y].Item = null;
                            player.Strength += item.Strength;
                        }
                        else if (player.LeftHandItems.Count == 1 && player.RightHandItems.Count == 1)
                        {
                            lastStatusItem = "Can't pick up, Your hands are full";
                        }
                    }
                    else if (item is Potion)
                    {
                        lastStatusItem = $"You fed on a {item.Name} and gained {item.Health} in health";
                        player.Health += item.Health + 1;
                        rooms[player.X, player.Y].Item = null;
                    }
                }
            }
            else
                lastStatusItem = null;
            if (keyPress == ConsoleKey.Escape)
                SGP.QuitGame();
            
            if (keyPress == ConsoleKey.I)
                SGP.CheckInventory(player);
            
            if (keyPress == ConsoleKey.D1)
            {
                do
                {
                    Console.Clear();
                    AGP.DisplayPlayerInfo(player, lastStatusEnemy, lastStatusItem);
                    AGP.DisplayWorld(player, rooms);
                    AskForCommand(Console.ReadKey().Key);
                } while (player.Health > 0 && Enemy.EnemyCount > 0);
                Console.ResetColor();
            }
            if (keyPress == ConsoleKey.D2)
            {
                do
                {
                    Console.ResetColor();
                    SGP.DisplayPlayerInfo(player, lastStatusEnemy, lastStatusItem);
                    SGP.DisplayWorld(player, rooms);
                    AskForCommand(Console.ReadKey().Key);
                } while (player.Health > 0 && Enemy.EnemyCount > 0);
                Console.ResetColor();
            }
        }
        private void CreateRooms()
        {            
            rooms = new Room[worldWidth, worldHeight];            
            for (int y = 0; y < worldHeight; y++)
            {
                for (int x = 0; x < worldWidth; x++)
                {
                    rooms[x, y] = new Room(RandomUtils.Random(100));

                    int randomValue = RandomUtils.Random(100);
                    int randomValue2 = RandomUtils.Random(100);
                    int randomValue3 = RandomUtils.Random(100);

                    //##Placerar ut Weapons på spelplanen##

                    if (randomValue < 4 && rooms[x, y] != rooms[0,0] ) 
                    {                        
                        rooms[x, y].Item = new Weapon("a Iron Pipe", 25, 3, 0,(char)212);
                    }
                    if (randomValue > 4 && randomValue <= 8 && rooms[x, y] != rooms[0, 0])
                    {
                        rooms[x, y].Item = new Weapon("a Rust Crowbar", 20, 5, 0,(char)182);
                    }
                    if (randomValue > 8 && randomValue <= 12 && rooms[x, y] != rooms[0, 0])
                    {
                        rooms[x, y].Item = new Weapon("an Old Showel",  10, 8, 0,(char)200);
                    }
                    if (randomValue > 12 && randomValue <= 18 && rooms[x, y] != rooms[0, 0])
                    {
                        rooms[x, y].Item = new Weapon("a Fire Hatchet", 10, 12, 0,(char)169);
                    }

                    //##Placerar ut Health Potions på spelplanen##

                    if (randomValue2 < 20 && rooms[x, y] != rooms[0, 0]) 
                    {
                        string[] potionsList = File.ReadAllLines(@"GameText/Name/PotionName.txt");
                        int rndPotionValue = RandomUtils.Random(potionsList.Length-1);
                        string potionName = potionsList[rndPotionValue];               
                        rooms[x, y].Item = new Potion(potionName, 0, 0, RandomUtils.Random(15,25),(char)177);
                    } 
                    if (randomValue3 < 15 && rooms[x, y] != rooms[0, 0] && rooms[x, y].Item == null && rooms[x,y].Enemy == null)
                    {
                        if (RandomUtils.Try(30))
                        {
                            string[] dogList = File.ReadAllLines(@"GameText/Name/DogName.txt");
                            int rndDogValue4 = RandomUtils.Random(dogList.Length - 1);
                            string dogName = dogList[rndDogValue4];
                            int strength = RandomUtils.Random(5, 10);

                            rooms[x, y].Enemy = new Dog(dogName, strength, 5,(char)21);
                        }
                        else if (RandomUtils.Try(70))
                        {
                            string[] humanList = File.ReadAllLines(@"GameText/Name/HumanName.txt");
                            int rndhumanValue4 = RandomUtils.Random(humanList.Length - 1);
                            string humanName = humanList[rndhumanValue4];
                            int strength = RandomUtils.Random(5, 10);

                            rooms[x, y].Enemy = new Human(humanName, strength, RandomUtils.Random(10, 16), (char)216);
                        }
                    }
                }
            }           
        }
    }
}
