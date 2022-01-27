using NUnit.Framework;
using Moq;
using Kaeshi.Entity;
using Kaeshi.Commands;
using Kaeshi.Interfaces;

namespace Kaeshi.Tests.CommandsTests
{
    public class UseCommandTests
    {
        [Test]
        public void UseCommandReturnsPlayWithNullItem()
        {
            var expected = GameState.Play;

            var target = new Mock<IBattler>();

            var command = new UseCommand(null, target.Object);

            var actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UseCommandReturnsPlayWithItem()
        {
            var expected = GameState.Play;

            var target = new Mock<IBattler>();

            var item = new UsableItem("foo", "bar", 1, (x => x.IsAlive()));

            var command = new UseCommand(item, target.Object);

            var actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }
    }
}
