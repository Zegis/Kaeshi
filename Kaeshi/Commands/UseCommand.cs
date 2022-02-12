using Kaeshi.Entity;
using Kaeshi.Interfaces;
using System;

namespace Kaeshi.Commands
{
    public class UseCommand : ICommand
    {
        private readonly IBattler _target;
        private readonly UsableItem _item;

        public UseCommand(UsableItem itemToUse,IBattler target)
        {
            _item = itemToUse;
            _target = target;
        }

        public GameState Execute()
        {
            if(_item == null)
            {
                Console.WriteLine("Nothing to use...");
            }
            else
            {
                _item.Use(_target);
            }

            return GameState.Play;
        }
    }
}
