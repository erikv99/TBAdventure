using System;
using TBAdventure.Super;

namespace TBAdventure.Object
{
    class Player : Entity
    {
        public Player(string name, int level, int health, int power, int defense) : base(name, level, health, power, defense) { }
        public void LevelUp() 
        {
            // Rounding it up (if 0.5 or higher) not sure why we're not using floats instead of integers tho :D
            Health = (int)Math.Round(Health * 1.5);
            Power = (int)Math.Round(Power * 1.5);
            Defense = (int)Math.Round(Defense * 1.5);
            Level++;
            Console.WriteLine("[LEVEL UP] Player {0} has leveled up and is now level {1}", Name, Level);
        }
    }
}
