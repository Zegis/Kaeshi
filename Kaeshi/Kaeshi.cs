using Keshi.Entity;
using Keshi.Modules;
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

            Character hero = CharacterFactory.Generate(rnd);

            Console.WriteLine("Strength: {0}", hero.Strength);
            Console.WriteLine("Dexterity: {0}", hero.Dexterity);
            Console.WriteLine("Life: {0}", hero.Life);

            var game = true;
            while(game)
            {
                var rawCommand = Console.ReadLine();
                var command = CommandParser.Parse(rawCommand);
                game = command.Execute();
            }
        }
    }
}
