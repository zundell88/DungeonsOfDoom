using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class RandomUtils
    {
        static Random rnd = new Random();            

        static public int Random(int max)
        {            
            return Random(1, max);
        }
        static public int Random(int min, int max)
        {
            return rnd.Next(min, max + 1);
        }
        static public bool Try(int procent)
        {
            int slumptal = Random(100);
            if (slumptal < procent)         
                return true;            
            else
                return false;

            //Slumpa fram tal 1 - 100
            // om slumptalet är mindre än procenten
            // då returneras true
            // annars false            
        }
    }
}
