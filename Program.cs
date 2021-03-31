using System;
using TBAdventure.Object;
using TBAdventure.DataStructures;

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

// Game is missing a absolute ton of validation, holding back on it for now. (since requirements change every week)

namespace TBAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            //CombatManager combatManager = new CombatManager();
            //Player hero = new Player("Erik", 1, 35, 2, 3, 1);
            //Console.WriteLine("**** Welcome to the text based adventure game! ****");
            //combatManager.Setup(hero, true, 3);

            //combatManager.FightLoop();

            // Creating a new linkedList
            Linkd myLinkedList = new Linkd();

            // setting the head then creating some nodes.
            myLinkedList.head = new Linkd.Node("Start");
            Linkd.Node secondNode = new Linkd.Node("Node 2");
            Linkd.Node thirdNode = new Linkd.Node("Node 3");
            Linkd.Node finalNode = new Linkd.Node("Final node");

            myLinkedList.head.next = secondNode;
            secondNode.next = thirdNode;
            thirdNode.next = finalNode;

        }
    }
}
