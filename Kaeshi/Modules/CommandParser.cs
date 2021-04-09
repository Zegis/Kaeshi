using Kaeshi.Commands;
using Kaeshi.Entity;
using Kaeshi.Interfaces;
using System;
namespace Kaeshi.Modules
{
    public class CommandParser
    {
        private readonly IEntityManager entityManager;

        public CommandParser(IEntityManager manager)
        {
            entityManager = manager;
        }

        public ICommand Parse(string rawCommand)
        {
            if (string.IsNullOrEmpty(rawCommand))
                return new NotFoundCommand();

            rawCommand = rawCommand.Trim().ToLower();
            var commandPieces = rawCommand.Split(' ');

            if(commandPieces.Length == 0 || commandPieces.Length > 2)
                return new NotFoundCommand();

            string rawTarget = String.Empty;

            if(commandPieces.Length > 1)
            {
                rawTarget = commandPieces[1];
            }

            switch(commandPieces[0])
            {
                case "look":
                    var target = entityManager.GetVisibleObject(rawTarget);
                    return new LookCommand(target);
                case "north":
                case "east":
                case "south":
                case "west":
                    var map = entityManager.GetMap();
                    var moveDirection = (Direction) Enum.Parse(typeof(Direction), commandPieces[0], true);
                    return new GoCommand(map, moveDirection);
                case "take":
                    var item = entityManager.GetItem(rawTarget);
                    return new TakeCommand(entityManager.GetHero(), item);
                case "attack":
                    var npc = entityManager.GetTargetableObject(rawTarget);
                    return new AttackCommand(entityManager.GetHero(),npc);
                case "exit": return new ExitCommand();
                default: return new NotFoundCommand();
            }
        }
    }
}
