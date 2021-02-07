using Keshi.Entity;
using Keshi.Interfaces;
using Keshi.Modules;
using System;

namespace Keshi.Commands
{
    class AttackCommand : ICommand
    {
        IBattler _target;
        IBattler _attacker;


        public AttackCommand(IBattler attacker ,IBattler target)
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
                _target.Injure(_attacker.GetDamage());
            }

            hitValue = Dice.Throw(_target.GetHitValue());
            if(_attacker.IsHit(hitValue))
            {
                _attacker.Injure(_target.GetDamage());
            }

            return GameState.Play;
        }
    }
}
