using Keshi.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keshi.Modules
{
    class CommandParser
    {
        public static ICommand Parse(string rawCommand)
        {
            if (string.IsNullOrEmpty(rawCommand))
                return new NotFoundCommand();

            switch(rawCommand)
            {
                case "exit": return new ExitCommand();
            }

            return new NotFoundCommand();
        }
    }
}
