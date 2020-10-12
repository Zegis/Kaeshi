using Keshi.Entity;
using Keshi.Interfaces;
using Keshi.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keshi.Commands
{
    class AttackCommand : ICommand
    {
        ITargetable _target;
        IAttacker _attacker;


        public AttackCommand(IAttacker attacker ,ITargetable target)
        {
            _attacker = attacker;
            _target = target;
        }

        public GameState Execute()
        {
            if (_target == null)
            {
                Console.Write("Nothing to attack");
                return GameState.Play;
            }

            var hitValue = Dice.Throw(_attacker.GetHitValue());
            if (_target.isHit(hitValue))
            {
                _target.Attack(0);
            }

            return GameState.Play;
        }
    }
}
