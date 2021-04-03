using Kaeshi.Entity;
using Kaeshi.Interfaces;
using System;

namespace Kaeshi.Commands
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
