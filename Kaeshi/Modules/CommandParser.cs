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

            string target = "hero";

            switch(rawCommand)
            {
                case "look": return new LookCommand(visibleObjects[target]);
                case "exit": return new ExitCommand();
                default: return new NotFoundCommand();
            }
        }
    }
}
