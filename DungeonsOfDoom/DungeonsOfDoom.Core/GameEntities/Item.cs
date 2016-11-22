using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core
{
    abstract class Item : GameEntities
    {        
        public Item(string name,int duration,int strength,int health,char symbole) : base (symbole, name)
        {
            Duration = duration;
            Health = health;
            Strength = strength;           
        }             
        public int Duration { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }        
    }
    class Potion : Item
    {
        public Potion(string name, int duration, int strength, int health, char symbole) : base (name, duration, strength, health, symbole)
        {                                    
        }      
    }
    class Weapon : Item
    {        
        public Weapon(string name, int duration, int strength, int health, char symbole) : base (name, duration, strength, health,symbole)
        {                  
        }                
    }
}
