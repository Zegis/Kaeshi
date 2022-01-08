using Kaeshi.Entity;
using Keshi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keshi.Entity
{
    public class UsableItem : Item, IUsable
    {
        private int _usesRemaining;

        UsableItem(string name, string description, int maxUses): base(name, description)
        {
            _usesRemaining = maxUses;
        }

        public void Use()
        {
            if (_usesRemaining == 0)
                Console.Write("Item is depleted");

            _usesRemaining--;
            Console.Write($"Used {Name}");
        }

        public override string Observe()
        {
            return $"{Name}\r\n{Description}\r\nUses Left: {_usesRemaining}";
        }
    }
}
