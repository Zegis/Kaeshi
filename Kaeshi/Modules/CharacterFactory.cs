using Keshi.Entity;
using Keshi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keshi.Modules
{
    public class CharacterFactory
    {
        static public Character Generate()
        {
            var ret = new Character
            {
                Strength = Dice.Throw(),
                Dexterity = Dice.Throw()
            };
            ret.Life = ret.Strength * 10;

            return ret;
        }
    }
}
