using System;
using TBAdventure.Super;

namespace TBAdventure.Object
{
    class Potion : Item
    {
        public int HealAmount { get; set; }
        public Potion(string name, string description, int healAmount) : base(name, description) 
        {
            HealAmount = healAmount;
        }
        public override void Use(Entity entity) 
        {
            entity.Health += HealAmount;
            Console.WriteLine("[POTION] {0} has used a potion and gained {1} health!", entity.Name, HealAmount);
        }
    }
}
