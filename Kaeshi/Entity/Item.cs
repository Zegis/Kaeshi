namespace Kaeshi.Entity
{
    public class Item
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

    }
}
