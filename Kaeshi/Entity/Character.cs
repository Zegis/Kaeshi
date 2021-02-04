using Keshi.Interfaces;
using Keshi.Modules;
using System;
using System.Text;

namespace Keshi.Entity
{
    public class Character: IVisible, ITargetable, IAttacker
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Life { get; set; }

        public void Attack(int damage)
        {
            Console.Write("Direct hit!");
            Life -= damage;
            if (Life == 0)
                Console.Write("Death");
        }

        public int GetHitValue()
        {
            return Dexterity;
        }

        public int GetDamage()
        {
            return Strength;
        }

        public bool isHit(int hitValue)
        {
            
            var defence = Dice.Throw(Dexterity);
            Console.WriteLine($"Trying to hit with {hitValue} against {defence}");
            if (hitValue >= defence)
                return true;

            return false;
        }

        public string Observe()
        {
            var description = new StringBuilder();

            if (Life > 0)
            {

                description.AppendLine($"Strength: {this.Strength}");
                description.AppendLine($"Dexterity: {this.Dexterity}");
                description.AppendLine($"Life: {this.Life}");
            }
            else
            {
                description.AppendLine("Dead body");
            }

            return description.ToString();
        }
    }
}
