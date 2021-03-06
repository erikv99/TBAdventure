using System;
using TBAdventure.Object;
using TBAdventure.Super;

// Known issues / Todo's:
// If player kills enemy and his defense becomes higher then the enemies attack he will always block and become pretty much immortal. will wait to see what else needs to be made in the game before changing this.
// Balance health / power / defense (unbalanced)
// Maybe put more code in other sections to make Main less crowded.
// Change message for use armor or use weapon

namespace TBAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Player hero = new Player("Erik", 1, 35, 2, 3);
            Enemy monster = new Enemy("Australian Spider", 1, 10, 2, 2);
            // Making a counter to make it more easier to see which spider is which
            int counter = 1;
            string playerInput;

            Console.WriteLine("**** Welcome to the text based adventure game! ****");
            while (true)
            {
                // Checking if player is dead, if so breaking out of the game loop
                if (hero.IsDead())
                {
                    break;
                }

                // Getting user input
                Console.Write("\n[>] Enter desired command to execute: ");
                playerInput = Console.ReadLine();
                Console.Write("\n");

                switch (playerInput.ToLower()) 
                {
                    case "attack":
                        hero.Attack(monster, 12);
                        break;
                    
                    // In case the playerInput starts with "use "
                    case string input when input.StartsWith("use "):

                        // Removing first 4 chars "use " to get just the item the user wants to use
                        string itemName = input.Remove(0, 4);

                        // Checking if the player his inventory actually contains the item
                        if (hero.GetItemFromInventory(itemName) != null) 
                        {
                            // Getting the first matching item from the players inventory
                            Item item = hero.GetItemFromInventory(itemName);
                            
                            // Using the item
                            item.Use(hero);

                            // Checking if the item was a Potion and deleting it from inventory if true.
                            if (item is Potion) 
                            {
                                hero.RemoveFromInventory(item);
                            }
                        }
                        else 
                        {
                            Console.WriteLine("[INVENTORY] item {0} is not present in inventory!, turn skipped!", itemName);
                        }
                        break;

                    default:
                        Console.WriteLine("[!] Command {0} is not a valid command, turn skipped!", playerInput);
                        break;
                }

                // Checking if monster is dead, if so leveling up the player and making a new monster. if not letting the monster attack the player
                if (monster.IsDead())
                {
                    hero.LevelUp();
                    monster = new Enemy("Australian Spider " + counter.ToString(), 1, 10, 2, 2);
                    counter++;
                } 
                else 
                {
                    monster.Attack(hero, 8);
                }
                hero.ShowStats();
            }
            Console.WriteLine("You have been defeated. GAME OVER!");
        }
    }
}
