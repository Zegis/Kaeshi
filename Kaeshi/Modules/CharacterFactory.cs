using Kaeshi.Entity;

namespace Kaeshi.Modules
{
    public static class CharacterFactory
    {
        static public Character Generate()
        {
            int strength = Dice.Throw();
            int dexterity = Dice.Throw();
            int maxLife = strength * 5;
            var ret = new Character(strength, dexterity, maxLife);

            return ret;
        }
    }
}
