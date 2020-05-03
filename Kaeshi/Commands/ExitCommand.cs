using Keshi.Entity;
using System;

namespace Keshi.Commands
{
    class ExitCommand : ICommand
    {
        public GameState Execute()
        {
            Console.WriteLine("Will exit");
            return GameState.Exit;
        }
    }
}
