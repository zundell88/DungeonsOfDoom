using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace DungeonsOfDoom.Core
{
    class Player : Creature
    {
        public int WorldWidth;
        public int WorldHeight;
        private int y;
        private int x;
        public List<Item> LeftHandItems { get; set; }
        public List<Item> RightHandItems { get; set; }
        public List<Enemy> Stomach { get; set; }

        public Player(string name, int health, int worldWidth, int worldHeight, int armor, int strength, char symbole) : base(name, health, armor, strength, symbole)
        {
            this.WorldHeight = worldHeight;
            this.WorldWidth = worldWidth;
            LeftHandItems = new List<Item>();
            RightHandItems = new List<Item>();
            Stomach = new List<Enemy>();
            foreach (char c in name)
            {
                if (char.IsDigit(c))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new ArgumentException(Environment.NewLine + "Name cannot contain numbers!");            
                }
                else
                {
                    Name = name;
                }
            }
        }
        public int X
        {
            get { return x; }
            set
            {
                if (value >= 0 && value < WorldWidth)
                    x = value;
            }
        }
        public int Y
        {
            get { return y; }
            set
            {
                if (value >= 0 && value < WorldHeight)
                    y = value;
            }
        }
        public static string GetPlayerName()
        {
            string playerName;
            bool isInputInvalid;
            do
            {                
                Console.Write("                                   ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                StringFunctions.MarqueeSlow("NAME YOUR MONSTER: ");
                Console.ResetColor();
                playerName = Console.ReadLine().ToUpper();
                isInputInvalid = string.IsNullOrEmpty(playerName) || playerName[0] == '$' || !playerName.Any(c => char.IsDigit(c));
                if (isInputInvalid == false)
                    CenterText.WriteCenterLine("Name cannot contain numbers!");
                else if (playerName == "")
                    playerName = "HumanSlayer";

            } while (isInputInvalid == false);
            return playerName;
        }
    }
}
