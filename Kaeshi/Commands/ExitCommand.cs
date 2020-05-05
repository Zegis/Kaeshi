using Keshi.Entity;
using System;

namespace Keshi.Commands
{
    public class ExitCommand : ICommand
    {
        public GameState Execute()
        {
            Console.WriteLine("Will exit");
            return GameState.Exit;
        }
    }
}
