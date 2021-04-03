using Kaeshi.Entity;
using Kaeshi.Interfaces;

namespace Kaeshi.Commands
{
    public class GoCommand : ICommand
    {
        private IMap level;
        private Direction moveDirection;
        public GoCommand(IMap lvl, Direction moveDir)
        {
            level = lvl;
            moveDirection = moveDir;
        }

        public GameState Execute()
        {
            level.Go(moveDirection);

            return GameState.Play;
        }
    }
}
