using System;
using TBAdventure.Super;

namespace TBAdventure.Object
{
    class Armor : Item
    {
        public int DefenseAmount { get; set; }
        public Armor(string name, string description, int defenseAmount) : base(name, description) 
        {
            DefenseAmount = defenseAmount;
        }
        public override void Use(Entity entity)
        {
            entity.Defense += DefenseAmount;
            Console.WriteLine("[ARMOR] {0} has gained a armor and gained {1} defense!", entity.Name, DefenseAmount);
        }
    }
}
