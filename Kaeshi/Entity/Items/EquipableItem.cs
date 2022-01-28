using System;
using System.Collections.Generic;
using System.Text;

namespace Kaeshi.Entity
{
    public class EquipableItem: Item
    {
        public readonly int _modificator;

        public EquipableItem(string name, string description, int modificator) : base(name, description)
        {
            _modificator = modificator;
        }

        public int GetModificator()
        {
            return _modificator;
        }
    }
}
