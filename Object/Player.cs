using System;
using System.Collections.Generic;
using TBAdventure.Super;

namespace TBAdventure.Object
{
    class Player : Entity
    {
        private List<Item> playerInventory = new List<Item>();
        
        public Player(string name, int level, int health, int power, int defense) : base(name, level, health, power, defense) 
        {
            playerInventory.Add(new Potion("Healing potion", "Heals the player", 25));
            playerInventory.Add(new Weapon("Rusty sword", "A old rusty sword", 5));
            playerInventory.Add(new Armor("Rusty breastplate", "A old rusty breastplate", 5));
        }
        
        public void LevelUp() 
        {
            // Rounding it up (if 0.5 or higher) not sure why we're not using floats instead of integers tho :D
            Health = (int)Math.Round(Health * 1.5);
            Power = (int)Math.Round(Power * 1.5);
            Defense = (int)Math.Round(Defense * 1.5);
            Level++;
            Console.WriteLine("[LEVEL UP] Player {0} has leveled up and is now level {1}", Name, Level);
        }
        
        public void AddItemToInventory(Item item) 
        {
            playerInventory.Add(item);
        }

        public void RemoveFromInventory(Item item) 
        {
            playerInventory.Remove(item);
        }

        // Function will return a the first item with the specified name, if not found will return null
        public Item GetItemFromInventory(string itemName) 
        {
            // Looping thru the inventory (list)
            for (int i = 0; i < playerInventory.Count; i++) 
            {
                // Checking if the current item matches the given name
                if (playerInventory[i].Name.ToLower() == itemName)
                {
                    return playerInventory[i];
                }
            }
            return null;
        }
    }
}
