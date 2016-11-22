﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Utils;

namespace DungeonsOfDoom.Core
{
   sealed class GameBanner
    {

        public static void PrintBanner()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            var starttxt = File.ReadAllText(@"GameText/StartText/GameLogo.txt");
            Console.WriteLine(starttxt);
            Console.ResetColor();
        }
        public static void PrintGameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            var gameOvertxt = File.ReadAllText(@"GameText/GameOver/GameOvertext.txt");
            Console.WriteLine(gameOvertxt + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine);
            Console.ResetColor();
        }
        public static void PrintLevelComplete()
        {
            Console.WriteLine(Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Red;
            var levelComplete = File.ReadAllText(@"GameText/LevelComplete/CompleteText.txt");
            Console.WriteLine(levelComplete + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine);
            Console.ResetColor();
        }
        public static void PrintGameStory()
        {
            string story = File.ReadAllText(@"GameText/StartText/GameStory.txt");
            StringFunctions.MarqueeFast(story);
            Console.ReadLine();
        }
        public static void PrintInventory(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            var handText = File.ReadAllText(@"GameEntities/Player/Backpack/handText.txt");
            Console.WriteLine(handText);
            Console.WriteLine(Environment.NewLine + Environment.NewLine);
            Console.ResetColor();
            if (player.LeftHandItems.Count > 0)
                Console.Write($"                 Left|hand:[{player.LeftHandItems[0].Name}]");
            else
                Console.Write("                      Left|hand: Is empty");
            if (player.RightHandItems.Count > 0)
                Console.WriteLine($"         Right|hand:[{player.RightHandItems[0].Name}]");
            else
                Console.Write("             Righ|hand: Is empty");
            Console.WriteLine(Environment.NewLine + Environment.NewLine + Environment.NewLine);
            CenterText.WriteCenterLine("Press any key to return...");
        }
    }
}
