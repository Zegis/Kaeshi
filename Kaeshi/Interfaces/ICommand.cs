using Kaeshi.Entity;

namespace Kaeshi.Interfaces
{
    public interface ICommand
    {
        public GameState Execute();
    }
}
