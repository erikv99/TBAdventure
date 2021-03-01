using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBAdventure.Super
{
    class Entity
    {
        private string Name { get; set; }
        private int Level { get; set; }
        private int Health { get; set; }
        private int Power { get; set; }
        private int Defense { get; set; }

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
            Console.WriteLine("Entity {0} has died!", Name);
            Health = 0;
        }
        protected void TakeDamage(int damage)
        {
            // Checking if entity is already dead 
            if (Health == 0)
            {
                Console.WriteLine("Entity {0} is already dead!", Name);
                return;
            }

            // Checking if defense is more then damage (attack blocked)
            if (Defense >= damage) 
            {
                Console.WriteLine("Entity {0} blocked incoming attack!", Name);
                return;
            }

            damage -= Defense;

            // Checking if the entity is dead.
            if (Health - damage <= 0) 
            {
                Death();
                return;
            }

            Health -= damage;
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
