using Kaeshi.Commands;
using Kaeshi.Entity;
using Kaeshi.Interfaces;
using Moq;
using NUnit.Framework;

namespace Kaeshi.Tests.CommandsTests
{
    class OpenInventoryCommandTests
    {
        [Test]
        public void OpenInventoryCommandReturnsPlay()
        {
            var expected = GameState.Play;

            var character = new Mock<IBackpack>();
            var command = new OpenInventoryCommand(character.Object);

            var actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }
    }
}
