using Kaeshi.Entity;
using Kaeshi.Interfaces;
using System;

namespace Kaeshi.Commands
{
    public class OpenInventoryCommand : ICommand
    {
        private readonly Character _player;

        public OpenInventoryCommand(Character player)
        {
            _player = player;
        }

        public GameState Execute()
        {
            Console.Write(_player.DisplayBackpack());
            return GameState.Play;
        }
    }
}
