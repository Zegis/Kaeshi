using Kaeshi.Entity;
using Kaeshi.Interfaces;
using Kaeshi.Modules;
using System;

namespace Kaeshi.Commands
{
    public class AttackCommand : ICommand
    {
        private readonly IBattler _enemy;
        private readonly IBattler _hero;
        private readonly Location _battleground;


        public AttackCommand(IBattler hero ,IBattler enemy, Location battleground)
        {
            _hero = hero;
            _enemy = enemy;
            _battleground = battleground;
        }

        public GameState Execute()
        {
            if (_enemy == null)
            {
                Console.Write("Nothing to attack");
                return GameState.Play;
            }

            PerformAttack(_hero,_enemy);

            if (!_enemy.IsAlive())
            {
                foreach(var item in _enemy.DropItems())
                {
                    _battleground.AddItem(item.Name, item);
                }
                return GameState.Play;
            }

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
                target.Injure(attacker.Damage());
            }
        }
    }
}
