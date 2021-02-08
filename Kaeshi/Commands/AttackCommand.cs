using Keshi.Entity;
using Keshi.Interfaces;
using Keshi.Modules;
using System;

namespace Keshi.Commands
{
    class AttackCommand : ICommand
    {
        IBattler _enemy;
        IBattler _hero;


        public AttackCommand(IBattler hero ,IBattler enemy)
        {
            _hero = hero;
            _enemy = enemy;
        }

        public GameState Execute()
        {
            if (_enemy == null)
            {
                Console.Write("Nothing to attack");
                return GameState.Play;
            }

            PerformAttack(_hero,_enemy);

            if(!_enemy.IsAlive())
                return GameState.Play;

            PerformAttack(_enemy, _hero);

            if(_hero.IsAlive())
                return GameState.Play;

            return GameState.Lost;
        }

        private void PerformAttack(IBattler attacker, IBattler target)
        {
            if (!target.IsAlive())
            {
                Console.Write("Target is unconcious");
                return;
            }

            var hitValue = Dice.Throw(attacker.GetHitValue());
            if (target.IsHit(hitValue))
            {
                target.Injure(attacker.GetDamage());
            }
        }
    }
}
