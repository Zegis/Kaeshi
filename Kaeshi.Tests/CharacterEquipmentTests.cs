using Kaeshi.Entity;
using NUnit.Framework;

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
    }
}
