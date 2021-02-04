using Keshi.Entity;
using Keshi.Interfaces;
using Keshi.Modules;
using System;

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

            if(!_target.IsAlive())
            {
                Console.Write("Target is dead");
                return GameState.Play;
            }

            var hitValue = Dice.Throw(_attacker.GetHitValue());
            if (_target.IsHit(hitValue))
            {
                _target.Attack(_attacker.GetDamage());
            }

            return GameState.Play;
        }
    }
}
