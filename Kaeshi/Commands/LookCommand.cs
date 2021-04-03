using Kaeshi.Entity;
using Kaeshi.Interfaces;
using System;

namespace Kaeshi.Commands
{
    public class LookCommand : ICommand
    {
        private readonly IVisible _visible;

        public LookCommand(IVisible target)
        {
            _visible = target;
        }

        public GameState Execute()
        {
            var description = _visible != null ? _visible.Observe() : "nothing to look at\n";
            Console.Write(description);

            return GameState.Play;
        }
    }
}
