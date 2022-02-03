using Kaeshi.Commands;
using Kaeshi.Entity;
using NUnit.Framework;

namespace Kaeshi.Tests.CommandsTests
{
    class UnEquipCommandTests
    {
        [Test]
        public void UnEquipCommandReturnsPlay()
        {
            var expected = GameState.Play;
            var command = new UnequipCommand();

            var actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }
    }
}
