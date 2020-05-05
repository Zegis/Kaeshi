using Keshi.Entity;

namespace Keshi.Commands
{
    public interface ICommand
    {
        public GameState Execute();
    }
}
