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
        public override void Use(Player player)
        {
            // If the weapon slot is not empty
            if (player.WeaponSlot != null)
            {
                // Setting power back to base amount (this does include level ups (minus the armor influencing the level up)
                player.Power = player.BasePower;
                // Adding the item in the Weapon slot back to the inventory
                player.AddItemToInventory(player.WeaponSlot);
                Console.WriteLine("[WEAPON] Weapon {0} has been unequipped!", player.WeaponSlot.Name);
            }

            // Setting the weapon slot to the current item 
            player.WeaponSlot = this;
            // Adding the power from the armor to the player power
            player.Power += PowerAmount;
            // Removing the current item from the inventory
            player.RemoveFromInventory(this);
            Console.WriteLine("[WEAPON] Weapon {0} has been equipped and increased power by {1} points!", this.Name, PowerAmount);
        }
    }
}
