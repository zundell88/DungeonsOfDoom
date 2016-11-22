using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsOfDoom.Core;
using Utils;

namespace DungeonsOfDoom
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 95;
            Console.WindowHeight = 50;
            try
            {
                Game game = new Game();
                game.Start();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Ett fel uppstod: {e.Message}");
            }
        }
    }
}
