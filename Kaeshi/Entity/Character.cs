﻿using Kaeshi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kaeshi.Entity
{
    public class Character : IVisible, IBattler, IBackpack, IEquipment
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        private int _life { get; set; }
        public bool _isAlive { get; private set; }

        public List<Item> Backpack {get; private set;}

        public Dictionary<EquippableType,EquippableItem> Equipment { get; private set; }

        private int Defence { get { return Dexterity; } }

        public Character(int strength, int dexterity, int maxLife)
        {
            Strength = strength;
            Dexterity = dexterity;
            _life = maxLife;
            _isAlive = true;

            Backpack = new List<Item>();
            Equipment = new Dictionary<EquippableType, EquippableItem>();
        }

        public void PutInBackpack(Item item)
        {
            Backpack.Add(item);
        }

        public string DisplayBackpack()
        {
            if (Backpack.Count == 0)
                return "You have no items in backpack...";

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
            UsableItem ret;
            try
            {
                 ret = (UsableItem)Backpack.First(x => itemName.Equals(x.Name,StringComparison.OrdinalIgnoreCase));
            }
            catch(InvalidOperationException)
            {
                ret = null;
            }

            return ret;
        }

        public EquippableItem GetEquippableItem(string itemName)
        {
            EquippableItem ret;
            try
            {
                ret = (EquippableItem)Backpack.First(x => itemName.Equals(x.Name, StringComparison.OrdinalIgnoreCase));
            }
            catch (InvalidOperationException)
            {
                ret = null;
            }

            return ret;
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

        public void Heal(int pointsToHeal)
        {
            if (_isAlive)
                _life += pointsToHeal;
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

        public void Equip(EquippableItem item, EquippableType type)
        {
            if(Equipment.TryAdd(type, item))
            {
                Backpack.Remove(item);
                Console.Write($"Equipped {item.Name} as {item.type}");
                return;
            }
            Console.Write($"You already use {item.type}");
        }

        public void Unequip(EquippableType type)
        {
            Equipment.Remove(type, out var item);
            if (item != null)
            {
                Backpack.Add(item);
                Console.Write($"Unequipped {item.Name} from {type}");
                return;
            }

            Console.Write($"You don't have {type} equipped");
        }
    }
}
