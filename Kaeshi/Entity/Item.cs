using Kaeshi.Interfaces;
using Keshi.Interfaces;

namespace Kaeshi.Entity
{
    public class Item: IVisible
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Item()
        {
            Name = string.Empty;
            Description = string.Empty;
        }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public virtual string Observe()
        {
            return $"{Name}\r\n{Description}";
        }
    }
}
