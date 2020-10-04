using System;
using System.Collections.Generic;
using System.Text;

namespace Keshi.Modules
{
    public class Dice
    {
        private static readonly Random rng = new Random();

        public static int Throw()
        {
            return rng.Next(1, 6);
        }
    }
}
