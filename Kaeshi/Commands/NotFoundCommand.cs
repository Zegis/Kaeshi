using Keshi.Entity;
using System;

namespace Keshi.Commands
{
    public class NotFoundCommand : ICommand
    {
        public GameState Execute()
        {
            Console.WriteLine("No command");
            return GameState.Play;
        }
    }
}
