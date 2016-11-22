using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Utils
{
    static public class StringFunctions
    {
        const int SleepTime =100;
        const int SleepTime2 = 5;
        
        public static void MarqueeSlow(string value)
        {
            foreach (char c in value)
            {
                Console.Write(c);
                Thread.Sleep(StringFunctions.SleepTime); 
            }
            
        }
        public static void MarqueeFast(string value)
        {
            foreach (char c in value)
            {
                Console.Write(c);
                Thread.Sleep(StringFunctions.SleepTime2);
            }

        }
        public static string Truncate(string value, int length)
        {
            if (value.Length <= length)
                return value;
            else
                return value.Substring(0, length);
        }
    }
}
