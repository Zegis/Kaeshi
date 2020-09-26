using Keshi.Entity;
using System;

namespace Keshi.Commands
{
    class GoCommand : ICommand
    {
        private Map level;
        private Direction moveDirection;
        public GoCommand(Map lvl, Direction moveDir)
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
