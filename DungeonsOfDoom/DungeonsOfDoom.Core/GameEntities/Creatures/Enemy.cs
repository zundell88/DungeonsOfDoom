using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace DungeonsOfDoom.Core
{    
    abstract class Enemy : Creature
    {
        public static int EnemyCount { get; private set; }
        public static int KilledEnemyCount{ get; private set; }

        public Enemy(string name, int strength, int health, char symbole) : base (name, health, 10, strength, symbole)
        {            
            EnemyCount++;           
        }
        public override void Fight(Creature opponent)
        {
            base.Fight(opponent); 
            if (this.Health <= 0) 
            {                
                EnemyCount--;                
                KilledEnemyCount++;
            }            
        }
        public static void PlayerDies(Player player)
        {
            EnemyCount = 0;
            if (player.Health <= 0)
            {
                KilledEnemyCount = 0;
            }
        }
    }
    class Human : Enemy
    {
        public Human (string name, int strength, int health, char symbole) : base (name, strength, health, symbole)
        {
        }
        public override void Fight(Creature opponent)
        {
            base.Fight(opponent);
            if (opponent.Health > 150)
            {
                opponent.Health -= this.Strength;
                this.Strength += Utils.RandomUtils.Random(30);
            }
            else if (opponent.Health < 150)
            {
                opponent.Health -= this.Strength;
            }            
        }
    }
    class Dog : Enemy
    {
        public Dog(string name, int strength, int health, char symbole) : base (name, strength, health, symbole)
        {           
        }
        public override void Fight(Creature opponent)
        {
            base.Fight(opponent);
            opponent.Health -= Strength;
            this.Strength +=5;
        }        
    }
    class Boss : Enemy
    {
        public int WorldWidth;
        public int WorldHeight;
        private int y;
        private int x;
        public static int BossCount { get; set; }

        public Boss(string name, int health, int worldWidth, int worldHeight, int strength, char symbole) : base(name, strength, health, symbole)
        {
            BossCount++;
            this.WorldHeight = worldHeight;
            this.WorldWidth = worldWidth;
        }
        public override void Fight(Creature opponent)
        {
            base.Fight(opponent);
            opponent.Health -= Strength;
            this.Strength += 2;
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
    }    
}
