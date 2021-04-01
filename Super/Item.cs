using TBAdventure.Object;

namespace TBAdventure.Super
{
    class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }
        // Using Player as a parameter instead of entity, the use method is only used for a player and it is also much more easier down the line (see notes)
        public virtual void Use(Player player) 
        { 
        }
    }
}
