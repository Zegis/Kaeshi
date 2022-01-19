using Kaeshi.Interfaces;
using System;

namespace Kaeshi.Entity
{
    public class UsableItem : Item, IUsable
    {
        private int _usesRemaining;

        private readonly Action<IBattler> _usageEffect;

        public UsableItem(string name, string description, int maxUses, Action<IBattler> effect): base(name, description)
        {
            _usesRemaining = maxUses;
            _usageEffect = effect;
        }

        public void Use(IBattler target)
        {
            if (_usesRemaining == 0)
                Console.Write("Item is depleted");

            _usesRemaining--;
            _usageEffect(target);
            Console.Write($"Used {Name}; uses left: {_usesRemaining}");
        }

        public override string Observe()
        {
            return $"{Name}\r\n{Description}\r\nUses Left: {_usesRemaining}";
        }
    }
}
