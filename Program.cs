using System;
using TBAdventure.Object;
using TBAdventure.Super;

// Known issues / Todo's:
// If player kills enemy and his defense becomes higher then the enemies attack he will always block and become pretty much immortal. will wait to see what else needs to be made in the game before changing this.
// Balance health / power / defense (unbalanced)
// Maybe put more code in other sections to make Main less crowded.

// **** Notes (dutch) ****
// Dit waren aantekeningen die in het verslag moeten / zullen komen helaas ben ik nog niet zover dus heb ik ze hier eerst maar neer gezet aangezien ze wel van belang zijn.
//Properties gebruikt inplaats van zelf voor alles setters/getters maken.Dit is hetzelfde en aangezien er toch niets meer dan een waarde ophalen of wijzigen gedaan moest worden kon het prima.
//Ben me er van bewust dat je deze setters / getters op private of protected kan maken indien nodig of handig.

//Gebruikt PascalCase voor functies en properties aangezien het (volgens mij) de standaard is in .net, gebruik camelCase voor variabelen etc.

//Voor de Item::Use() methode ben ik Player player gaan gebruiken ipv van Entity entity. 
//In mijn mening was dit beter aangezien ik de player instancie nodig was en Weapon / Armor / Potion alleen door de speler kunnen worden gebruikt.

//Bij level up gaat de MaxHealth omhoog niet die Health zelf aangezien de speler anders vrij snel een juggernaut/tank wordt
//wel krijgt de speler 20% van de huidige max health erbij (na verhoging ivbm level up)

//Bij het(un)equippen van armor/weapon word deze in/uit de inventory gehaald zodat het geen duplicate wordt.

// Wanneer defense hoger is dan inkomende damage word het een block
namespace TBAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Player hero = new Player("Erik", 1, 35, 2, 3);
            Enemy monster = new Enemy("Australian Spider 1", 1, 10, 7, 5);
            // Making a counter to make it more easier to see which spider is which
            int counter = 2;
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
                        hero.Attack(monster, hero.Power);
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
                    hero.LevelUp();
                    monster = new Enemy("Australian Spider " + counter.ToString(), 1, 10, 4, 4);
                    counter++;
                } 
                else 
                {
                    monster.Attack(hero, monster.Power);
                }
                hero.ShowStats();
            }
            Console.WriteLine("You have been defeated. GAME OVER!");
        }
    }
}
