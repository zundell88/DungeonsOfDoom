using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core
{
    class Room
    { 
        public Room(int brightness)
        {
            Brightness = brightness;            
        }
        public int Brightness { get; set; }
        public Item Item { get; set; }
        public Enemy Enemy { get; set; }
        public Boss Boss { get; set; }
    }
}
