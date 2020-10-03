using Keshi.Entity;
using Keshi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keshi.Commands
{
    class AttackCommand : ICommand
    {
        ITargetable _target;

        public AttackCommand(ITargetable target)
        {
            _target = target;
        }

        public GameState Execute()
        {
            if (_target == null)
                Console.Write("Nothing to attack");
            else
                _target.Attack();

            return GameState.Play;
        }
    }
}
