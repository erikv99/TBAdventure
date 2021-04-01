using System;
using TBAdventure.Object;

namespace TBAdventure.DataStructures
{
    class Linkd
    {
        // Class variables for the Linkd class
        public Node head;
        private Player player;
        private bool playerCommandsEnabled;

        // Creating our node class inside our linked list class
        public class Node
        {
            public Node next;
            public string story;
            public bool combat;
            public int AmountOfEnemies { get; private set; }

            public Node(string story, bool combat = false, int amountOfEnemies = -1)
            {
                this.story = story;

                // Combat is false if not passed, otherwise it will be the given value 
                this.combat = combat;

                // If combat = true and amountOfEnemies is still -1 (not set / given) 
                if (combat == true && amountOfEnemies == -1)
                {
                    throw new ArgumentException("[!] CODE ERROR: Amount of enemies is not given for node constructor but combat is true.");
                }

                // If number of enemies is less then 1 
                if (combat == true && amountOfEnemies < 1)
                {
                    throw new ArgumentException("[!] CODE ERROR: Amount of enemies for combat node cannot be less then 1!");
                }

                AmountOfEnemies = amountOfEnemies;
            }
        }

        // Linked list methods

        // Linked list constructer requires player object and playerCommandsEnabled boolean (true if not passed)
        public Linkd(Player player, bool playerCommandsEnabled = true) 
        {
            this.player = player;
            this.playerCommandsEnabled = playerCommandsEnabled;
        }

        /// <summary>
        /// Function which runs the story line, make sure nodes are setup before
        /// </summary>
        public void RunStoryline()
        {
            Node currentNode = head;
            CombatManager combatManager = new CombatManager();

            Console.WriteLine("**** Welcome to the text based adventure game! ****");

            // Looping untill we hit the final node or untill the player has died
            while (currentNode != null && !player.IsDead()) 
            {
                Console.WriteLine("\n[STORY] " + currentNode.story + " [Press any key to continue]");
                Console.ReadKey(true);

                if (currentNode.combat) 
                {
                    try 
                    {
                        combatManager.Setup(player, playerCommandsEnabled, currentNode.AmountOfEnemies);
                        combatManager.FightLoop();
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("\n" + e.Message + "\n");
                        break;
                    }
                }
                // Setting current node to the next node in the list
                currentNode = currentNode.next;
            }
        }
    }
}
