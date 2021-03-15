using TBAdventure.Super;

namespace TBAdventure.Object

{
    class Enemy : Entity
    {
        public Enemy(string name, int level, int health, int power, int defense, int speed) : base(name, level, health, power, defense, speed) { }
    }
}
