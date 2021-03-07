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
        public override void Use(Player player)
        {
            // If the armor slot is not empty
            if (player.ArmorSlot != null) 
            {
                // Setting Defense back to base amount (this does include level ups (minus the armor influencing the level up)
                player.Defense = player.BaseDefense;
                // Adding the item in the armor slot back to the inventory
                player.AddItemToInventory(player.ArmorSlot);
                Console.WriteLine("[ARMOR] Armor {0} has been unequipped!", player.ArmorSlot.Name);
            }

            // Setting the armor slot to the current item 
            player.ArmorSlot = this;
            // Adding the defense from the armor to the player defense
            player.Defense += DefenseAmount;
            // Removing the current item from the inventory
            player.RemoveFromInventory(this);
            Console.WriteLine("[ARMOR] Armor {0} has been equipped and increased defense by {1} points!", this.Name, DefenseAmount);
        }
    }
}
