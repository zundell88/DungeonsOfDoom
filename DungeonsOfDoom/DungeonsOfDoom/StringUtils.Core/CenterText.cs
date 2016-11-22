using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class CenterText
    {
        public static void WriteCenterLine(string text)
        {
            int width = Console.WindowWidth;
            int fill = (width - text.Length) / 2;
            string spaces = new string(char.Parse(" "), fill);
            Console.WriteLine(spaces + text);
        }
        public static void WriteCenter(string text)
        {
            int width = Console.WindowWidth;
            int fill = (width - text.Length) / 2;
            string spaces = new string(char.Parse(" "), fill);
            Console.Write(spaces + text);
        }
    }
}
