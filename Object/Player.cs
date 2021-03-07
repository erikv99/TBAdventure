using System;
using System.Collections.Generic;
using TBAdventure.Super;

namespace TBAdventure.Object
{
    class Player : Entity
    {
        private List<Item> playerInventory = new List<Item>();
        public int BaseHealth { set; get; }
        public int BasePower { set; get; }
        public int BaseDefense { set; get; }
        public int MaxHealth { set; get; }
        public Armor ArmorSlot { set; get; }
        public Weapon WeaponSlot { set; get; }
        public Player(string name, int level, int health, int power, int defense) : base(name, level, health, power, defense) 
        {
            playerInventory.Add(new Potion("Healing potion", "Heals the player", 25));
            playerInventory.Add(new Weapon("Rusty sword", "A old rusty sword", 5));
            playerInventory.Add(new Armor("Rusty breastplate", "A old rusty breastplate", 5));
            playerInventory.Add(new Potion("Supreme potion", "Heals the player", 50));
            playerInventory.Add(new Weapon("Iron sword", "A Iron sword", 10));
            playerInventory.Add(new Armor("Iron breastplate", "A Iron breastplate", 10));
            BaseHealth = health;
            BasePower = power;
            BaseDefense = defense;
            MaxHealth = health;
        }
        
        public void LevelUp() 
        {
            // Rounding it up (if 0.5 or higher) not sure why we're not using floats instead of integers tho :D
            // Note: When leveling up i increase the MaxHealth not the Health itself (see notes)
            MaxHealth = (int)Math.Round(MaxHealth * 1.5);
            Power = (int)Math.Round(Power * 1.5);
            Defense = (int)Math.Round(Defense * 1.5);
            // Increasing the current base values with 1.5 (so not including weapon or armor etc)
            BasePower = (int)Math.Round(BasePower * 1.5);
            BaseDefense = (int)Math.Round(BaseDefense * 1.5);
            BaseHealth = (int)Math.Round(BaseHealth * 1.5);
            // Increasing level and giving player 20% of the new max health in hp.
            // Round function needs float or double so we cast maxhealth to float so it doesn't do an integer division
            int healthBonus = (int)Math.Round((float)MaxHealth / 100 * 20);
            Health += healthBonus;
            Level++;
            Console.WriteLine("[LEVEL UP] Player {0} has leveled up and is now level {1} a {2} HP increase has been granted!", Name, Level, healthBonus);
        }

        public override void ShowStats()
        {
            base.ShowStats();
            Console.Write(">Max Health: {0}\n>Base Health: {1}\n>Base Power: {2}\n>Base Defense: {3}\n", MaxHealth, BaseHealth, BasePower, BaseDefense);
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
