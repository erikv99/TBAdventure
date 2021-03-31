using System;
using System.Collections.Generic;
using TBAdventure.Super;

namespace TBAdventure.Object
{
    class CombatManager
    {
        private bool playerCommandsEnabled = true; // Enabled by default
        private Player player = null;
        private bool gameHasBeenSetup = false;
        private Queue<Entity> fightQueue = new Queue<Entity>();

        /// <summary>
        /// Function which uses a bubble sort algorithm to order the entities in descending order based on speed. Will return a Queue of entities
        /// </summary>
        private Queue<Entity> GetFightOrder(Entity[] arrayOfEntities)
        {
            // if lenght is 1 we dont have to sort it
            if (arrayOfEntities.Length != 1)  
            {
                // Looping thru all the entities given, looping through 1 less then the length of the collection since we compare it to the number after it (left to right)
                for (int i = 0; i < arrayOfEntities.Length - 1; i++)
                {

                    // Declaring a temp var here so it doesn't have to be made and destroyed each iteration. (used in swapping the smaller num forward
                    Entity temp;

                    // I is the number we compare against the other numbers 
                    // The "length - (1 + i)" is so that after each iteration of the outer loop we dont compare it against 1 more from the right (so after 1 iteration we compare against original array -1, after 2 iterations we compare against org array - 2 etc
                    for (int j = 0; j < arrayOfEntities.Length - (1 + i); j++)
                    {
                        // Checking if current num is smaller then the next
                        if (arrayOfEntities[j].Speed < arrayOfEntities[j + 1].Speed)
                        {
                            // if it is smaller then the next we swap the smaller number forward (this will happen n times so it will be at the end at the list by the end. of this inner for loop
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

        /// <summary>
        /// Will return a random decimal value between param min and max
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>A decimal value</returns>
        private decimal GetRandomDecimal(decimal min, decimal max) 
        {
            Random rand = new Random();

            // Getting a random int between our lower and upperbound (+1 since end is non inclusive) 
            int randomInt = rand.Next((int)(min * 100), (int)(max * 100 + 1));

            // Dividing our random int by a 100
            decimal randomDecimal = (decimal)randomInt / 100;
            return randomDecimal;
        }

        /// <summary>
        /// Function to generate an X amount of enemies and return an array. 
        /// </summary>
        /// <param name="numberOfEnemies"></param>
        /// <returns> an array of Enemy Objects </returns>
        private Enemy[] GetEnemies(int numberOfEnemies) 
        {
            // List of possible monster names the program will choose from (source: https://list.fandom.com/wiki/List_of_monsters#Greek_mythology)
            String[] monsterNames = new string[] 
            { "Charybdis", "Chimera", "Cyclops", "Dryad", "Dracon", "Dragon", "Echidna", 
                "Empusa", "Gigantes", "Griffin", "Gorgon", "Harpy", "Hecatonchires", "Hippocamp",
                "Hydra", "Kallikantzaros", "Karkinos", "Kronos", "Ladon", "Lamia", "Medusa", "Minotaur",
                "Nyaid", "Nemean Lion", "Orthus", "Pegasus", "Python", "Roc", "Satyr", "Scylla", "Siren" };

            // Creating a instance of random class (needed later)
            Random rand = new Random();

            // Base values for the monsters (lvl 1 base values)
            int baseMonsterHealth = 10;
            int baseMonsterPower = 5;
            int baseMonsterDefense = 2;

            // Monster level will be equal to the round number
            int monsterLevel = player.Level;

            // Monster Health, Power and Defense will be baseValue * (level + random num between 0.00 and 0.7) then cast to int so we get stronger and less stronger monsters
            // Example: random decimal is 0.20; level is 2; health = health * 2,20 (then casted to int (rounded up)
            int monsterHealth = (int)Math.Round(baseMonsterHealth * ((decimal)monsterLevel + GetRandomDecimal(0.0M, 0.7M)));
            int monsterPower = (int)Math.Round(baseMonsterPower * ((decimal)monsterLevel + GetRandomDecimal(0.0M, 0.7M)));
            int monsterDefense = (int)Math.Round(baseMonsterDefense * ((decimal)monsterLevel + GetRandomDecimal(0.0M, 0.7M)));

            // Creating a enemies array the size of numberOfEnemies
            Enemy[] enemies = new Enemy[numberOfEnemies];

            // Creating the required amount of monsters
            for (int i = 0; i < numberOfEnemies; i++) 
            {
                // Picking a name from our monster list for the monster we're making (picks a num between 0 and monsterNames length -1,)
                string monsterName = monsterNames[rand.Next(monsterNames.Length)];

                // Picking a speed between 1 and a 100
                int monsterSpeed = rand.Next(1, 101);

                // Creating a new enemy and adding it to the array of enemies.
                Enemy enemy = new Enemy(monsterName, monsterLevel, monsterHealth, monsterPower, monsterDefense, monsterSpeed);

                // Adding current enemy to array
                enemies[i] = enemy;
            }

            return enemies;
        }
        
        public void Setup(Player player, bool playerCommandsEnabled, int numberOfEnemies)
        {   
            // Checking if the numberOfEnemies is atleast 1. 
            if (numberOfEnemies < 1)
            {
                throw new ArgumentException("\n[!] CODE ERROR: Setup failed, number of enemies must atleast be 1!\n");
            }

            // Overriding the setup is allowed
            if (gameHasBeenSetup) 
            {
                Console.Write("\n[!] Game has already been set up, overriding setup");
            }

            // Assigning the parameter values to the class variables
            this.player = player;
            this.playerCommandsEnabled = playerCommandsEnabled;

            // Getting the enemies
            Enemy[] enemies = GetEnemies(numberOfEnemies);

            // Sorting the enemies by speed
            fightQueue = GetFightOrder(enemies);

            Console.WriteLine("[SETUP] Setup successfull!");
            gameHasBeenSetup = true;
        }
        public bool FightLoop() 
        {
            // Checking if the game has been setup
            if (!gameHasBeenSetup) 
            {
                Console.WriteLine("[!] CODE ERROR: FightLoop() cannot be used since game has not been setup yet!");
                return false;
            }

            // Some variables that need to be outside of the while loop scope.
            string playerInput;
            Enemy monster = null;
 
            // While player isn't dead and there are still enemies to fight
            while (!player.IsDead() && fightQueue.Count != 0)
            {
                // If monster is dead or has yet to be assigned we assign it
                if (monster == null || monster.IsDead()) 
                {
                    // Trying to dequeue and cast the entity to a enemy. catching the cast exception so we can procceed. (if somehow a player got in the fight queue, pretty much impossible the way the code is setup)
                    try
                    {
                        monster = (Enemy)fightQueue.Dequeue();
                    }
                    catch (InvalidCastException)
                    {
                        Console.WriteLine("[!] CODE ERROR: Next entity in queue cannot be cast to enemy. dequing and proceeding");
                    }
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

                // Checking if monster is dead, if so leveling up the player, if not letting the monster attack the player
                if (monster.IsDead())
                {
                    player.LevelUp();
                }
                else
                {
                    monster.Attack(player, monster.Power);
                }
                player.ShowStats();
            }
            Console.WriteLine("You have been defeated. GAME OVER!");
            return false;
        }
    }
}
