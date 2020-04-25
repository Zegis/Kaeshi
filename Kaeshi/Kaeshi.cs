using System;

namespace Kaeshi
{
    class Kaeshi
    {
        static void Main(string[] args)
        {
            var seed = 1010;
            Console.WriteLine("Your character:");
            var rnd = new Random(seed);
            var strength = rnd.Next(1, 6);
            var dexterity = rnd.Next(1, 6);
            var life = strength * 10;

            Console.WriteLine("Strength: {0}", strength);
            Console.WriteLine("Dexterity: {0}", dexterity);
            Console.WriteLine("Life: {0}", life);
        }
    }
}
