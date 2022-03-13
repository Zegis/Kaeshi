using Kaeshi.Entity;
using Kaeshi.Interfaces;
using System;

namespace Kaeshi.Commands
{
    public class OpenInventoryCommand : ICommand
    {
        private readonly IBackpack _player;

        public OpenInventoryCommand(IBackpack player)
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
