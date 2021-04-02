using System;
using TBAdventure.Object;
using TBAdventure.DataStructures;

namespace TBAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating our player
            Player hero = new Player("Erik", 1, 35, 4, 3, 1);
   
            // Creating a new linkedList (storyline) change params to (hero, false) to disable player input
            Linkd storyLineLL = new Linkd(hero);

            // Creating our node objects
            Linkd.Node segment2, segment3, segment4, segment5, segment6, segment7;

            // setting the head then initializing our node objects
            try 
            {
                storyLineLL.head = new Linkd.Node("You wake up confused, not sure where you are or how you got there.");
                segment2 = new Linkd.Node("You're in a forrest surrounded by trees. You start walking hoping to find a sign of life.");
                segment3 = new Linkd.Node("A screaming noice in the distance gives you goosebumps. You start running the other way. Right in to the deeper part of the forrest.");
                segment4 = new Linkd.Node("Suddenly you hear something running behind you, you turn around and draw your sword.", true, 3);
                segment5 = new Linkd.Node("You are worn out from the battle, but continue on your journey towards safety.");
                segment6 = new Linkd.Node("Suddenly you find yourself standing on a road.");
                segment7 = new Linkd.Node("Eventually you see a group of travelers and you find safety in numbers along your journey.");
            }
            catch (ArgumentException e) 
            {
                Console.WriteLine("\n" + e.Message + "\n");
                return;
            }

            // Setting the head of each node then running the story line
            storyLineLL.head.next = segment2;
            segment2.next = segment3;
            segment3.next = segment4;
            segment4.next = segment5;
            segment5.next = segment6;
            segment6.next = segment7;
            storyLineLL.RunStoryline();
        }
    }
}
