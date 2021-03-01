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
            Console.WriteLine("Your character: ");

            Character hero = CharacterFactory.Generate();

            Console.WriteLine(hero.Observe());

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

            if(game == GameState.Lost)
            {
                Console.WriteLine();
                Console.WriteLine("You lost :(");
                Console.ReadKey();
            }
        }
    }
}
