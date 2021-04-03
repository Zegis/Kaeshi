using Kaeshi.Entity;
using Kaeshi.Interfaces;
using System;

namespace Kaeshi.Commands
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
