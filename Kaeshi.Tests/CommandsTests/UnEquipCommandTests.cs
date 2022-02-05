using Kaeshi.Commands;
using Kaeshi.Entity;
using Kaeshi.Interfaces;
using Moq;
using NUnit.Framework;

namespace Kaeshi.Tests.CommandsTests
{
    class UnEquipCommandTests
    {
        [Test]
        public void UnEquipCommandReturnsPlay()
        {
            var expected = GameState.Play;
            var equipment = new Mock<IEquipment>();
            var command = new UnequipCommand(equipment.Object, EquippableType.Armor);

            var actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UnEquipCommandExecutesUnequip()
        {
            var equipment = new Mock<IEquipment>();
            equipment.Setup((x) => x.Unequip(It.IsAny<EquippableType>())).Verifiable();

            var command = new UnequipCommand(equipment.Object, EquippableType.Armor);

            command.Execute();

            equipment.Verify(x => x.Unequip(It.IsAny<EquippableType>()), Times.Once);
        }
    }
}
