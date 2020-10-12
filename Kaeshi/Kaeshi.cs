using Keshi.Entity;
using Keshi.Modules;
using System;

namespace Kaeshi
{
    class Kaeshi
    {
        static void Main(string[] args)
        {
            Dice.setSeed(1010);
            Console.WriteLine("Your character:");

            Character hero = CharacterFactory.Generate();

            Console.WriteLine("Strength: {0}", hero.Strength);
            Console.WriteLine("Dexterity: {0}", hero.Dexterity);
            Console.WriteLine("Life: {0}", hero.Life);

            var map = new Map();

            var entityManager = new EntityManager();
            entityManager.SetHero(hero);
            entityManager.SetMap(map);

            var commandParser = new CommandParser(entityManager);

            var game = GameState.Play;
            while(game == GameState.Play)
            {
                Console.Write("\n> ");
                var rawCommand = Console.ReadLine();
                var command = commandParser.Parse(rawCommand);
                game = command.Execute();
            }
        }
    }
}
