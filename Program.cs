using System;
using TBAdventure.Object;

// Known issues / Todo's:
// If player kills enemy and his defense becomes higher then the enemies attack he will always block and become pretty much immortal. will wait to see what else needs to be made in the game before changing this.
// Balance health / power / defense (unbalanced)

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

                    case string input when input.StartsWith("use"):
                        
                        // Splitting the string on a blank space 
                        string[] splitOutput = playerInput.Split(' ');
                        
                        // Checking if there were atleast 2 words
                        if (splitOutput.Length > 1) 
                        { 
                            // Join togheter with spaces inbetween??
                            .. Todo
                        }
                        // TODO continue on the use, check if the second part of player input is a valid use 
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
            }
            Console.WriteLine("You have been defeated. GAME OVER!");
        }
    }
}
