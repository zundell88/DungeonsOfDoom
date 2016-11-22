using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core
{
    abstract class GameEntities
    {
        public char Symbole { get; set; }
        public string Name { get; set; }

        public GameEntities(char symbole, string name)
        {
            this.Symbole = symbole;
            this.Name = name;
        }       
    }
}
