using Kaeshi.Entity;
using Kaeshi.Interfaces;

namespace Kaeshi.Commands
{
    public class TakeCommand : ICommand
    {
        private readonly IBackpack backpack;
        private readonly Item item;

        public TakeCommand(IBackpack characterBackpack, Item itemToTake)
        {
            backpack = characterBackpack;
            item = itemToTake;
        }

        public GameState Execute()
        {
            backpack.PutInBackpack(item);
            return GameState.Play;
        }
    }
}
