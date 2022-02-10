using Kaeshi.Entity;
using NUnit.Framework;
using System.Collections.Generic;

namespace Kaeshi.Tests
{
    class CharacterEquipmentTests
    {
        [Test]
        public void CanEquipItemToEmptySpace()
        {
            var sut = new Character(1, 1, 1);
            var item = new EquippableItem("foo", "bar", 0, EquippableType.Armor);
            sut.PutInBackpack(item);

            sut.Equip(item, EquippableType.Armor);

            Assert.IsNotNull(sut.Equipment[EquippableType.Armor]);
        }

        [Test]
        public void CanNotEquipItemToFilledSpace()
        {
            var sut = new Character(1, 1, 1);
            sut.Equipment[EquippableType.Armor] = new EquippableItem("bar", "foo", 0, EquippableType.Armor);
            var item = new EquippableItem("foo", "bar", 0, EquippableType.Armor);
            sut.PutInBackpack(item);

            sut.Equip(item, EquippableType.Armor);

            Assert.AreNotEqual(sut.Equipment[EquippableType.Armor].Observe(),item.Observe());
        }

        [Test]
        public void EquipedItemIsNotInBackpack()
        {
            var sut = new Character(1, 1, 1);
            var item = new EquippableItem("foo", "bar", 0, EquippableType.Armor);
            sut.PutInBackpack(item);

            sut.Equip(item, EquippableType.Armor);

            Assert.IsNull(sut.GetEquippableItem(item.Name));
        }

        [Test]
        public void UnequipCleansEquipmentSlot()
        {
            var sut = new Character(1, 1, 1);
            var item = new EquippableItem("foo", "bar", 0, EquippableType.Armor);

            sut.Equipment.Add(EquippableType.Armor, item);

            sut.Unequip(EquippableType.Armor);

            Assert.Throws<KeyNotFoundException>( () => item = sut.Equipment[EquippableType.Armor]);
        }

        [Test]
        public void UnequipAddsItemToBackpack()
        {
            var sut = new Character(1, 1, 1);
            var item = new EquippableItem("foo", "bar", 0, EquippableType.Armor);

            sut.Equipment.Add(EquippableType.Armor, item);

            Assert.AreEqual(0, sut.Backpack.Count);

            sut.Unequip(EquippableType.Armor);

            Assert.AreEqual(1, sut.Backpack.Count);
            Assert.AreEqual(item.Description, sut.GetEquippableItem("foo").Description);
        }

        [Test]
        public void WeaponsGiveDamageBonus()
        {
            var sut = new Character(1, 1, 1);
            var item = new EquippableItem("foo", "bar", 1, EquippableType.Weapon);

            Assert.AreEqual(1, sut.GetDamage());

            sut.Equip(item, EquippableType.Weapon);

            Assert.AreEqual(2, sut.GetDamage());

        }
    }
}
