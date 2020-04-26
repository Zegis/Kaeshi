using Keshi.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keshi.Modules
{
    public class CharacterFactory
    {
        static public Character Generate(Random rnd)
        {
            var ret = new Character
            {
                Strength = rnd.Next(1, 6),
                Dexterity = rnd.Next(1, 6)
            };
            ret.Life = ret.Strength * 10;

            return ret;
        }
    }
}
