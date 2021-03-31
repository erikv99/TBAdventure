using System;
using TBAdventure.Object;

namespace TBAdventure.DataStructures
{
    class Linkd
    {
        public Node head;

        // Creating our node class inside our linked list class
        public class Node
        {
            public Node next;
            public string story;
            public bool combat;

            public Node(string story, bool combat = false, int amountOfEnemies = -1)
            {
                this.story = story;

                // Combat is false if not passed, otherwise it will be the given value 
                this.combat = combat;

                // If combat = true and amountOfEnemies is still -1 (not set / given) 
                if (combat == true && amountOfEnemies == -1) 
                {
                    throw new ArgumentException("\n[!] CODE ERROR: Amount of enemies is not given for node constructor but combat is true.\n");
                }

                // If number of enemies is less then 1 
                if (combat == true && amountOfEnemies < 1) 
                {
                    throw new ArgumentException("\n[!] CODE ERROR: Amount of enemies for combat node cannot be less then 1!\n");
                }
            }
        }

        // Linked list methods
        public void RunStoryline()
        {

            Node currentNode = head;

            // Looping untill we hit the final node
            while (currentNode != null) 
            {
                Console.WriteLine("\n[Story] " + currentNode.story + "\n");

                if (currentNode.combat) 
                { 
                    
                }
                // Setting current node to the next node in the list
                currentNode = currentNode.next;
            }
        }
    }
}
