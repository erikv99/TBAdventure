using System;
using System.Collections.Generic;
using TBAdventure.Super;

namespace TBAdventure.Object
{
    class CombatManager
    {
        private Queue<Entity> fightOrder;

        public void Setup(params Entity[] args)
        {
            // Bubble sort 
            // Looping thru all the entities given, looping through 1 less then the length of the collection since we compare it to the number after it (left to right)
            for (int i = 0; i < args.Length - 1; i++) 
            {

                // Declaring a temp var here so it doesn't have to be made and destroyed each iteration. (used in swapping the bigger num forward
                Entity temp;
             
                // I is the number we compare against the other numbers 
                // The "length - (1 + i)" is so that after each iteration of the outer loop we dont compare it against 1 more from the right (so after 1 iteration we compare against original array -1, after 2 iterations we compare against org array - 2 etc
                for (int j = 0; j < args.Length - (1 + i); j++) 
                { 
                    // Checking if current num is bigger then the next
                    if (args[j].Speed > args[j + 1].Speed) 
                    {
                        // if it is bigger then the next we swap the biggest number forward (this will happen n times so it will be at the end at the list by the end. of this inner for loop
                        temp = args[j + 1];
                        args[j + 1] = args[j];
                        args[j] = temp;
                    }
                }
            }
            // Creating a new queue instance using the args array and putting it in our fightorder var
            fightOrder = new Queue<Entity>(args);
        }
        public bool FightLoop(bool playerCommandsEnabled = true) 
        {
            
        }
    }
}
