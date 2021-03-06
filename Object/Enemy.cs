using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBAdventure.Super;

namespace TBAdventure.Object

{
    class Enemy : Entity
    {
        public Enemy(string name, int level, int health, int power, int defense) : base(name, level, health, power, defense) { }
    }
}
