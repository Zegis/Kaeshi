using System;
using System.Collections.Generic;
using System.Text;

namespace Kaeshi.Entity
{
    public class EquipableItem: Item
    {
        public readonly int modificator;
        public readonly EquipableType type;

        public EquipableItem(string name, string description, int modificator, EquipableType itemType) : base(name, description)
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
