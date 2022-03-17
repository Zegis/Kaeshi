using Kaeshi.Entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kaeshi.Tests
{
    class IBattlerTests
    {
        [Test]
        public void InjureSubtractsLife()
        {
            var sut = new Character(0,0,10);

            var expectedLifeDescription = "Life: 8";
            sut.Injure(2);

            Assert.IsTrue(sut.IsAlive());
            Assert.IsTrue(sut.Observe().Contains(expectedLifeDescription));
        }

        [Test]
        public void InjureCanKill()
        {
            var sut = new Character(0, 0, 10);

            var expectedDescription = "Dead body" + Environment.NewLine;

            sut.Injure(10);
            Assert.IsFalse(sut.IsAlive());
            Assert.AreEqual(expectedDescription, sut.Observe());
        }

        [Test]
        public void HealIncreaseLife()
        {
            var sut = new Character(0, 0, 1);

            var expectedLifeDescription = "Life: 5";

            sut.Heal(4);

            Assert.IsTrue(sut.IsAlive());
            Assert.IsTrue(sut.Observe().Contains(expectedLifeDescription));
        }

        [Test]
        public void HealWontWorkOnDead()
        {
            var sut = new Character(0, 0, 1);
            var notExpectedLifeDescription = "Life: 11";
            sut.Injure(1);

            sut.Heal(10);

            Assert.IsFalse(sut.IsAlive());
            Assert.IsFalse(sut.Observe().Contains(notExpectedLifeDescription));
        }

        [Test]
        public void isHitReturnsTrueForValuesAboveDefence()
        {
            var sut = new Character(1, 2, 1);

            var result = sut.IsHit(3);

            Assert.IsTrue(result);
        }
        
        [Test]
        public void isHitReturnsTrueForValuesEqualTodefence()
        {
            var sut = new Character(1, 2, 1);

            var result = sut.IsHit(2);

            Assert.IsTrue(result);
        }

        [Test]
        public void isHitReturnsFalseForValuesBelowDefence()
        {
            var sut = new Character(1, 2, 1);

            var result = sut.IsHit(1);

            Assert.IsFalse(result);
        }

        [Test]
        public void DropItemsReturnsNoItemsWhenAliveAndNoItems()
        {
            var sut = new Character(1, 1, 1);

            var expected = Enumerable.Empty<Item>();

            var result = sut.DropItems();

            Assert.IsTrue(sut.IsAlive());
            Assert.AreEqual(expected, result);
            Assert.AreEqual(0, result.Count());
        }
        

        [Test]
        public void DropItemsReturnsNoItemsWhenAliveAndWithItems()
        {
            var sut = new Character(1, 1, 1);

            var exampleItem = new Item("Foo", "bar");
            var exampleUsableItem = new UsableItem("Foo", "bar", 1, (a) => a.Heal(2));

            var expectedResult = Enumerable.Empty<Item>();

            sut.PutInBackpack(exampleItem);
            sut.PutInBackpack(exampleUsableItem);

            var result = sut.DropItems();

            Assert.IsTrue(sut.IsAlive());
            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedResult.Count(), result.Count());
        }

        [Test]
        public void DropItemsReturnsNoItemsWhenDeadAndNoItems()
        {
            var sut = new Character(1, 1, 1);

            var expected = Enumerable.Empty<Item>();

            sut.Injure(2);

            var result = sut.DropItems();

            Assert.IsFalse(sut.IsAlive());
            Assert.AreEqual(expected, result);
            Assert.AreEqual(0, result.Count());
        }


        [Test]
        public void DropItemsReturnsAllItemsWhenDeadAndWithItems()
        {
            var sut = new Character(1, 1, 1);

            var exampleItem = new Item("Foo", "bar");
            var exampleUsableItem = new UsableItem("Foo", "bar", 1, (a) => a.Heal(2));

            var expectedResult = new List<Item>() {
                exampleItem, exampleUsableItem
            };

            sut.PutInBackpack(exampleItem);
            sut.PutInBackpack(exampleUsableItem);

            sut.Injure(2);
            var result = sut.DropItems();

            Assert.IsFalse(sut.IsAlive());
            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedResult.Count, result.Count());
        }

    }
}
