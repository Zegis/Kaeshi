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
        public void UseCommandReturnsPlay()
        {
            var expected = GameState.Play;

            var target = new Mock<IBattler>();

            var command = new UseCommand(null, target.Object);

            var actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }
    }
}
