using Kaeshi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kaeshi.Modules
{
    public static class EffectsLibrary
    {
        static readonly private Dictionary<string, Action<IBattler>> _effects;

        static EffectsLibrary()
        {
            _effects = new Dictionary<string, Action<IBattler>>
            {
                ["heal"] = (a) => a.Heal(2),
                ["damage"] = (a) => a.Injure(2)
            };
        }

        static public Action<IBattler> Get(string effectName)
        {
            try
            {
                return _effects[effectName];
            }
            catch(ArgumentNullException)
            {
                return null;
            }
            catch(KeyNotFoundException)
            {
                return null;
            }
        }
    }
}
