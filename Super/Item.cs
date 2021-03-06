using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBAdventure.Super
{
    class Item
    {
        // Even tho marked as public only the getter and setter are public
        public string Name { get; set; }
        public string Description { get; set; }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public virtual void Use(Entity entity) 
        { 
        }
    }
}
