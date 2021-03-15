using System;
using System.Collections.Generic;
using TBAdventure.Super;

namespace TBAdventure.Object
{
    class CombatManager
    {
        private bool playerCommandsEnabled = true; // Enabled by default
        private int numberOfEnemiesRequired = 1; // Must be specified by user
        private Player player = null;
        private bool gameHasBeenCreated = false;
        public CombatManager(Player player, bool playerCommandsEnabled, int numberOfEnemies)
        {
            this.player = player;
            this.playerCommandsEnabled = playerCommandsEnabled;
            numberOfEnemiesRequired = numberOfEnemies;
            gameHasBeenCreated = true;
            Console.WriteLine("**** Welcome to the text based adventure game! ****");
        }
        /// <summary>
        /// Function which uses a bubble sort algorithm to order the entities in descending order based on speed. Will return a Queue of entities
        /// </summary>
        private Queue<Entity> GetFightOrder(params Entity[] arrayOfEntities)
        {
            // if lenght is 1 we dont have to sort it
            if (arrayOfEntities.Length != 1)  
            {
                // Looping thru all the entities given, looping through 1 less then the length of the collection since we compare it to the number after it (left to right)
                for (int i = 0; i < arrayOfEntities.Length - 1; i++)
                {

                    // Declaring a temp var here so it doesn't have to be made and destroyed each iteration. (used in swapping the bigger num forward
                    Entity temp;

                    // I is the number we compare against the other numbers 
                    // The "length - (1 + i)" is so that after each iteration of the outer loop we dont compare it against 1 more from the right (so after 1 iteration we compare against original array -1, after 2 iterations we compare against org array - 2 etc
                    for (int j = 0; j < arrayOfEntities.Length - (1 + i); j++)
                    {
                        // Checking if current num is bigger then the next
                        if (arrayOfEntities[j].Speed > arrayOfEntities[j + 1].Speed)
                        {
                            // if it is bigger then the next we swap the biggest number forward (this will happen n times so it will be at the end at the list by the end. of this inner for loop
                            temp = arrayOfEntities[j + 1];
                            arrayOfEntities[j + 1] = arrayOfEntities[j];
                            arrayOfEntities[j] = temp;
                        }
                    }
                }
            }
            // Creating a new queue instance using the arrayOfEntities array and returning it
            return new Queue<Entity>(arrayOfEntities);
        }
        private void Setup(params Entity[] args)
        {

        }
        public bool FightLoop() 
        {
            // Making a counter to make it more easier to see which spider is which
            int counter = 2;
            string playerInput;
            Enemy monster = new Enemy("Australian Spider 1", 1, 10, 7, 5, 1);
            // Using fightOrder.Count as a way of tracking how many monsters are left to fight instead of building a function to check for it. why reinvent te wheel?
            // While player isn't dead and there are still enemies to fight
            while (!player.IsDead() && fightOrder.Count > 0)
            {
                // Checking if player is dead, if so breaking out of the game loop
                if (player.IsDead())
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
                        player.Attack(monster, player.Power);
                        break;

                    // In case the playerInput starts with "use "
                    case string input when input.StartsWith("use "):

                        // Removing first 4 chars "use " to get just the item the user wants to use
                        string itemName = input.Remove(0, 4);

                        // Checking if the player his inventory actually contains the item
                        if (player.GetItemFromInventory(itemName) != null)
                        {
                            // Getting the first matching item from the players inventory
                            Item item = player.GetItemFromInventory(itemName);

                            // Using the item
                            item.Use(player);

                            // Checking if the item was a Potion and deleting it from inventory if true.
                            if (item is Potion)
                            {
                                player.RemoveFromInventory(item);
                            }
                        }
                        else
                        {
                            Console.WriteLine("[INVENTORY] Item {0} is not present in inventory!, turn skipped!", itemName);
                        }
                        break;

                    default:
                        Console.WriteLine("[!] Command {0} is not a valid command, turn skipped!", playerInput);
                        break;
                }

                // Checking if monster is dead, if so leveling up the player and making a new monster. if not letting the monster attack the player
                if (monster.IsDead())
                {
                    player.LevelUp();
                    monster = new Enemy("Australian Spider " + counter.ToString(), 1, 10, 4, 4, 1);
                    counter++;
                }
                else
                {
                    monster.Attack(player, monster.Power);
                }
                player.ShowStats();
            }
            Console.WriteLine("You have been defeated. GAME OVER!");
        }
    }
}
