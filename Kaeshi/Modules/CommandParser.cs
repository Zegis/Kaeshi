using Keshi.Commands;
using Keshi.Entity;

namespace Keshi.Modules
{
    class CommandParser
    {
        public static ICommand Parse(string rawCommand, Character hero)
        {
            if (string.IsNullOrEmpty(rawCommand))
                return new NotFoundCommand();

            switch(rawCommand)
            {
                case "look": return new LookCommand(hero);
                case "exit": return new ExitCommand();
                default: return new NotFoundCommand();
            }
        }
    }
}
