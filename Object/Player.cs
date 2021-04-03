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
        
        private int currentXP = 0;
        private int neededXPToLevelUp;

        public Player(string name, int level, int health, int power, int defense, int speed) : base(name, level, health, power, defense, speed) 
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
            neededXPToLevelUp = 10 * (Level * Level);
        }
        
        /// <summary>
        /// Function to level up the player
        /// </summary>
        private void LevelUp() 
        {
            // Rounding it up (if 0.5 or higher) 
            // Note: When leveling up i increase the MaxHealth not the Health itself (see notes)
            MaxHealth = (int)Math.Round(MaxHealth * 1.5);

            // If weaponslot is empty we dont add the WeaponSlot.PowerAmount since it doesnt exist and will throw an error
            if (WeaponSlot == null)
            {
                Power = (int)Math.Round(Power * 1.5);
            }
            else
            {
                Power = (int)Math.Round(BasePower * 1.5) + WeaponSlot.PowerAmount;
            }

            // If armor is empty we dont add the ArmorSlot.DefenseAmount since it doesnt exist and will throw an error
            if (ArmorSlot == null)
            {
                Defense = (int)Math.Round(Defense * 1.5);
            }
            else
            {
                Defense = (int)Math.Round(BaseDefense * 1.5) + ArmorSlot.DefenseAmount;
            }

            // Increasing the current base values with 1.5 (so not including weapon or armor etc)
            BasePower = (int)Math.Round(BasePower * 1.5);
            BaseDefense = (int)Math.Round(BaseDefense * 1.5);
            BaseHealth = (int)Math.Round(BaseHealth * 1.5);

            // Increasing level and giving player 20% of the new max health in hp.
            // Round function needs float or double so we cast maxhealth to float so it doesn't do an integer division
            int healthBonus = (int)Math.Round((float)MaxHealth / 100 * 20);
            Health += healthBonus;
            Level++;
            Console.WriteLine("[LEVEL UP] Player {0} has leveled up and is now level {1}, a {2} HP increase has been granted!\n", Name, Level, healthBonus);
        }
        
        /// <summary>
        /// Function to add XP to the player, will level up when needed amount is reached
        /// </summary>
        /// <param name="amountOfExperience">Amount of XP to give to the player</param>
        public void GainXP(int amountOfExperience) 
        {
            Console.WriteLine("[XP GAINED] Player {0} gained {1} XP!\n", Name, amountOfExperience);
            currentXP += amountOfExperience; 
            
            // Checking if player is level up
            if (currentXP >= neededXPToLevelUp) 
            {
                // leveling up the player and increasing the needed xp to level up
                LevelUp();
                neededXPToLevelUp = 10 * (Level * Level);
            }
        }
        public override void ShowStats()
        {
            base.ShowStats();
            Console.Write(">Max Health: {0}\n>Base Health: {1}\n>Base Power: {2}\n>Base Defense: {3}\n>Current XP: {4}\n>XP need for next level: {5}\n\n", MaxHealth, BaseHealth, BasePower, BaseDefense, currentXP, neededXPToLevelUp);
        }

        public void AddItemToInventory(Item item) 
        {
            playerInventory.Add(item);
        }

        public void RemoveFromInventory(Item item) 
        {
            playerInventory.Remove(item);
        }

        public void ShowInventory() 
        {
            Console.WriteLine("[INVENTORY CONTENT]");
            for (int i = 0; i < playerInventory.Count; i++) 
            {
                Console.WriteLine("[" + (i + 1) + "] " + playerInventory[i].Name);
            }
            // Just to get a a new line behind the last item
            Console.WriteLine("");
        }

        /// <summary>
        /// Will return first item with the given name
        /// </summary>
        /// <param name="itemName">Name of the item to look for</param>
        /// <returns>The item with the given name or null when not found </returns>
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
