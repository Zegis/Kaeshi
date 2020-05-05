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
            var description = _visible != null ? _visible.Observe() : "nothing to look at";
            Console.Write(description);

            return GameState.Play;
        }
    }
}
