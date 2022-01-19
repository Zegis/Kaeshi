using Kaeshi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kaeshi.Entity
{
    public class Character : IVisible, IBattler, IBackpack
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        private int _life { get; set; }
        public bool _isAlive { get; private set; }

        public List<Item> Backpack {get; private set;}

        private int Defence { get { return Dexterity; } }

        public Character(int strength, int dexterity, int maxLife)
        {
            Strength = strength;
            Dexterity = dexterity;
            _life = maxLife;
            _isAlive = true;

            Backpack = new List<Item>();
        }

        public void PutInBackpack(Item item)
        {
            Backpack.Add(item);
        }

        public string DisplayBackpack()
        {
            var backpackView = new StringBuilder();
            foreach(Item i in Backpack)
            {
                backpackView.AppendLine(i.Observe());
            }

            return backpackView.ToString();
        }

        public void RemoveFromBackpack(Item item)
        {
            Backpack.Remove(item);
        }

        public UsableItem GetUsableItem(string itemName)
        {
            return (UsableItem)Backpack.First(x => itemName.Equals(x.Name));
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
            Console.WriteLine($"Trying to hit with {hitValue} against {Defence}");
            if (hitValue >= Defence)
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

                description.AppendLine($"\nYou have {this.Backpack.Count} item(s) in backpack");
            }
            else
            {
                description.AppendLine("Dead body");
            }

            return description.ToString();
        }
    }
}
