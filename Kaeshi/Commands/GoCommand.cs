using Kaeshi.Entity;
using Kaeshi.Interfaces;

namespace Kaeshi.Commands
{
    public class GoCommand : ICommand
    {
        private readonly IMap level;
        private readonly Direction moveDirection;
        public GoCommand(IMap lvl, Direction moveDir)
        {
            level = lvl;
            moveDirection = moveDir;
        }

        public GameState Execute()
        {
            if (level.Go(moveDirection))
                return GameState.Win;

            return GameState.Play;
        }
    }
}
