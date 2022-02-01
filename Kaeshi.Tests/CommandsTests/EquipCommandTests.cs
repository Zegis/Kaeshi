using Kaeshi.Commands;
using Kaeshi.Entity;
using Kaeshi.Interfaces;
using Moq;
using NUnit.Framework;

namespace Kaeshi.Tests.CommandsTests
{
    class EquipCommandTests
    {
        [Test]
        public void UseCommandReturnsPlayWithNullItem()
        {
            var expected = GameState.Play;

            var target = new Mock<IEquipment>();

            var command = new EquipCommand(target.Object,null);

            var actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UseCommandReturnsPlayWithItem()
        {
            var expected = GameState.Play;

            var target = new Mock<IEquipment>();

            var item = new EquippableItem("foo", "bar", 1, EquippableType.Armor);

            var command = new EquipCommand(target.Object, item);

            var actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }
    }
}
