using System;
using TBAdventure.Super;

namespace TBAdventure.Object
{
    class Weapon : Item
    {
        public int PowerAmount { get; set; }
        public Weapon(string name, string description, int powerAmount) : base(name, description) 
        {
            PowerAmount = powerAmount;
        }
        public override void Use(Entity entity)
        {
            entity.Power += PowerAmount;
            Console.WriteLine("[WEAPON] {0} has gained a new weapon and gained {1} power!", entity.Name, PowerAmount);
        }
    }
}
