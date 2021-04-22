using Kaeshi.Commands;
using Kaeshi.Interfaces;
using Kaeshi.Entity;
using Moq;
using NUnit.Framework;

namespace Kaeshi.Tests.CommandsTests
{
    public class TakeCommandTests
    {
        [Test]
        public void LookCommandReturnsPlay()
        {
            var expected = GameState.Play;

            Mock<IBackpack> backpack = new Mock<IBackpack>();
            var command = new TakeCommand(backpack.Object, new Item("test","description"));

            var actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LookCommandAddsToBackpack()
        {
            Mock<IBackpack> backpack = new Mock<IBackpack>();
            var item = new Item("test", "description");
            var command = new TakeCommand(backpack.Object, item);
            command.Execute();

            backpack.Verify(x => x.PutInBackpack(item), Times.Once);
        }
    }
}
