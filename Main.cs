using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using TBAdventure.Object;
namespace TBAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Player hero = new Player("Erik", 1, 35, 5, 5);
            Enemy monster = new Enemy("Australian Spider", 1, 10, 2, 2);
            // Making a counter to make it more easier to see which spider is which
            int counter = 1;

            while (!hero.IsDead())
            {
                // Checking if monster is dead, if so leveling up the player and making a new monster.
                if (monster.IsDead())
                {
                    hero.LevelUp();
                    monster = new Enemy("Australian Spider " + counter.ToString(), 1, 10, 2, 2);
                    counter++;
                }

                hero.Attack(monster, 12);
                monster.Attack(hero, 8);
            }
            Console.WriteLine("You have been defeated. GAME OVER!");
        }
    }
}
