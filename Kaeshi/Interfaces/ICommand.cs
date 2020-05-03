using Keshi.Entity;

namespace Keshi.Commands
{
    interface ICommand
    {
        public GameState Execute();
    }
}
