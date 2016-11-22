using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core
{
    class Creature : GameEntities
    {        
        public int Health { get; set; }
        public int Armor { get; set; }
        public int Strength { get; set; }
        public Creature(string name, int health, int armor, int strength, char symbole) : base (symbole, name)
        {
            Health = health;
            Armor = armor;
            Strength = strength;
        }        
        public virtual void Fight(Creature opponent)
        {
            opponent.Health -= this.Strength;
        }
    }
}
