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
        public override void Use(Player player) 
        {
            // Checking if potion exceeds max health
            if (player.Health + HealAmount > player.MaxHealth) 
            {
                // Setting health to max
                player.Health = player.MaxHealth;
                Console.WriteLine("[POTION] {0} has used a potion and is now max health!\n", player.Name);
            } 
            else 
            {
                // Adding the potion hp to the player hp
                player.Health += HealAmount;
                Console.WriteLine("[POTION] {0} has used a potion ({1}HP) and is now {2} health!\n", player.Name, HealAmount, player.Health);
            }
        }
    }
}
