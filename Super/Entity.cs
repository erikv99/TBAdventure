using System;

namespace TBAdventure.Super
{
    class Entity
    {
        public string Name { get; set; }
        // Level should only be changable by classes derived from the Entity class
        public int Level { get; protected set; }
        public int Health { get; set; }
        public int Power { get; set; }
        public int Defense { get; set; }

        public Entity(string name, int level, int health, int power, int defense) 
        {
            Name = name;
            Level = level;
            Health = health;
            Power = power;
            Defense = defense;
        }
        private void Death() 
        {
            Console.WriteLine("[DEATH] Entity {0} has died!", Name);
            Health = 0;
        }
        private void TakeDamage(int damage)
        {
            // Checking if entity is already dead 
            if (Health == 0)
            {
                return;
            }

            // Checking if defense is more then damage (attack blocked)
            if (Defense >= damage) 
            {
                Console.WriteLine("[BLOCKED] Entity {0} blocked incoming attack!", Name);
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
            Console.WriteLine("[DAMAGE] Entity {0} took {1} damage!", Name, damage);
        }
        public void Attack(Entity entity, int damage) 
        {
            entity.TakeDamage(damage);
        }
        public virtual void ShowStats() 
        {
            Console.Write("[STATS]\n>Name: {0}\n>Level: {1}\n>Health: {2}\n>Power: {3}\n>Defense: {4}\n", Name, Level, Health, Power, Defense);
        }
        public bool IsDead() 
        {
            if (Health <= 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}
