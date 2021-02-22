using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBAdventure.Super
{
    class Entity
    {
        private string name;
        private int level;
        private int health;
        private int power;
        private int defense;

        public Entity(string name, int level, int health, int power, int defense) 
        {
            this.name = name;
            this.level = level;
            this.health = health;
            this.power = power;
            this.defense = defense; 
        }
        private void Death() 
        {
            Console.WriteLine("Entity {0} has died!", name);
            health = 0;
        }
        protected void TakeDamage(int damage)
        {
            // Checking if entity is already dead 
            if (health == 0)
            {
                Console.WriteLine("Entity {0} is already dead!", name);
                return;
            }

            // Checking if defense is more then damage (attack blocked)
            if (defense >= damage) 
            {
                Console.WriteLine("Entity {0} blocked incoming attack!", name);
                return;
            }

            damage -= defense;

            // Checking if the entity is dead.
            if (health - damage <= 0) 
            {
                Death();
                return;
            }

            health -= damage;
            Console.WriteLine("Entity {0} took {1} damage!", name, damage);
        }
        protected void Attack(Entity entity, int damage) 
        {
            entity.TakeDamage(damage);
        }

        public void getStats() 
        {
           Console.Write("Name: {0}\nLevel: {1}")
        }
    }
}
