using Kaeshi.Entity;
using Kaeshi.Interfaces;
using Moq;
using NUnit.Framework;
using System;

namespace Kaeshi.Tests.Entity
{
    class UsableItemTests
    {

        [Test]
        public void UsingItemDecreasesCharges()
        {
            var expectedItem = new UsableItem("foo", "bar", 0, (x => x.IsAlive()));
            var target = new Mock<IBattler>();
            var item = new UsableItem("foo", "bar", 1, (x => x.IsAlive()));

            item.Use(target.Object);
            Assert.AreEqual(expectedItem.Observe(), item.Observe());
        }

        [Test]
        public void UsingItemWorks()
        {
            var action = new Mock<Action<IBattler>>();
            var target = new Mock<IBattler>();
            var item = new UsableItem("foo", "bar", 1, action.Object);

            item.Use(target.Object);

            action.Verify(x => x(target.Object), Times.Once);
        }

        [Test]
        public void UsingItemWontWorkWithoutCharges()
        {
            var action = new Mock<Action<IBattler>>();
            var target = new Mock<IBattler>();
            var item = new UsableItem("foo", "bar", 0, action.Object);

            item.Use(target.Object);

            action.Verify(x => x(target.Object), Times.Never);
        }
    }
}
