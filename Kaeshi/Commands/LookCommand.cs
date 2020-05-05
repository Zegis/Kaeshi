using Keshi.Entity;
using Keshi.Interfaces;
using System;

namespace Keshi.Commands
{
    public class LookCommand : ICommand
    {
        private IVisible _visible;

        public LookCommand(IVisible target)
        {
            _visible = target;
        }

        public GameState Execute()
        {
            Console.Write(_visible.Observe());

            return GameState.Play;
        }
    }
}
