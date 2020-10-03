using Keshi.Interfaces;
using System;
using System.Text;

namespace Keshi.Entity
{
    public class Character: IVisible, ITargetable
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Life { get; set; }

        public void Attack()
        {
            Console.Write("Direct hit!");
        }

        public string Observe()
        {
            var description = new StringBuilder();

            description.AppendLine($"Strength: {this.Strength}");
            description.AppendLine($"Dexterity: {this.Dexterity}");
            description.AppendLine($"Life: {this.Life}");

            return description.ToString();
        }
    }
}
