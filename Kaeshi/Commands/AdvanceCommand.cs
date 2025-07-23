using Kaeshi.Entity;
using Kaeshi.Interfaces;
using System;

namespace Kaeshi.Commands
{
    public class AdvanceCommand : ICommand
    {
        private readonly IMap _map;
        private readonly IBackpack _backpack;

        public AdvanceCommand(IMap map, IBackpack backpak) { 
            _map = map;
            _backpack = backpak;
        }

        public GameState Execute()
        {
            var currentLocation = _map.GetCurrentLocation();

            if (!currentLocation.final)
            {
                Console.WriteLine("There's no way to next floor here");
                return GameState.Play;
            }

            if(!string.IsNullOrEmpty(currentLocation.key) && _backpack.ItemInBackpack(currentLocation.key))
            {
                Console.WriteLine("You reached next floor!");
                _map.Advance();
                return GameState.Play;
            }

            Console.WriteLine($"You don't have a {currentLocation.key} to advance!");
            return GameState.Play;

        }
    }
}
