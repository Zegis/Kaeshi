using Kaeshi.Entity;
using Kaeshi.Interfaces;

namespace Kaeshi.Commands
{
    public class UnequipCommand : ICommand
    {
        public GameState Execute()
        {
            return GameState.Play;
        }
    }
}
