using Kaeshi.Entity;
using Kaeshi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kaeshi.Commands
{
    public class AdvanceCommand : ICommand
    {
        private readonly IMap _map;

        public AdvanceCommand(IMap map) { 
            _map = map;
        }

        public GameState Execute()
        {
            if (!_map.GetCurrentLocation().final)
                Console.WriteLine("There's no way to next floor here");
            else {
                Console.WriteLine("You reached next floor!");
                _map.Advance();
            }

            return GameState.Play;
        }
    }
}
