namespace Kaeshi.Entity
{
    public class EquippableItem: Item
    {
        public readonly int modificator;
        public readonly EquippableType type;

        public EquippableItem(string name, string description, int modificator, EquippableType itemType) : base(name, description)
        {
            this.modificator = modificator;
            type = itemType;
        }

        public int GetModificator()
        {
            return modificator;
        }
    }
}
