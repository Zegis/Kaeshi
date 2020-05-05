using Keshi.Commands;
using Keshi.Interfaces;
using System.Collections.Generic;

namespace Keshi.Modules
{
    public class CommandParser
    {
        public static Dictionary<string, IVisible> visibleObjects = new Dictionary<string, IVisible>();

        public static ICommand Parse(string rawCommand)
        {
            if (string.IsNullOrEmpty(rawCommand))
                return new NotFoundCommand();

            rawCommand = rawCommand.Trim();
            var commandPieces = rawCommand.Split(' ');

            if(commandPieces.Length == 0 || commandPieces.Length > 2)
                return new NotFoundCommand();

            switch(commandPieces[0])
            {
                case "look":
                    visibleObjects.TryGetValue(commandPieces[1],out var target);
                    return new LookCommand(target);
                case "exit": return new ExitCommand();
                default: return new NotFoundCommand();
            }
        }
    }
}
