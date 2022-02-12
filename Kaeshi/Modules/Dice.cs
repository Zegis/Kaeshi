using System;

namespace Kaeshi.Modules
{
    public static class Dice
    {
        private static Random rng = new Random();

        public static void setSeed(int seed)
        {
            rng = new Random(seed);
        }

        public static int Throw()
        {
            return rng.Next(1, 6);
        }

        public static int Throw(int modifier)
        {
            return rng.Next(1, 6) + modifier;
        }

        public static int Throw(int numberOfTimes, int modifier)
        {
            int sum = modifier;

            for(int i = 0; i<numberOfTimes; i++)
            {
                sum += Throw();
            }

            return sum;
        }
    }
}
