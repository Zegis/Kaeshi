using Keshi.Interfaces;
using Keshi.Modules;
using System;
using System.Text;

namespace Keshi.Entity
{
    public class Character: IVisible, IBattler
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        private int _life { get; set; }

        private bool _isAlive { get; set; }

        public Character(int strength, int dexterity, int maxLife)
        {
            Strength = strength;
            Dexterity = dexterity;
            _life = maxLife;
            _isAlive = true;
        }

        public void Injure(int damage)
        {
            Console.Write("Direct hit!");
            _life -= damage;
            if (_life == 0)
            {
                Console.Write("Death");
                _isAlive = false;
            }
        }

        public int GetHitValue()
        {
            return Dexterity;
        }

        public int GetDamage()
        {
            return Strength;
        }

        public bool IsHit(int hitValue)
        {
            
            var defence = Dice.Throw(Dexterity);
            Console.WriteLine($"Trying to hit with {hitValue} against {defence}");
            if (hitValue >= defence)
                return true;

            return false;
        }

        public bool IsAlive()
        {
            return _isAlive;
        }

        public string Observe()
        {
            var description = new StringBuilder();

            if (_isAlive)
            {

                description.AppendLine($"Strength: {this.Strength}");
                description.AppendLine($"Dexterity: {this.Dexterity}");
                description.AppendLine($"Life: {this._life}");
            }
            else
            {
                description.AppendLine("Dead body");
            }

            return description.ToString();
        }
    }
}
