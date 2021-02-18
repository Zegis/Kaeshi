using Keshi.Commands;
using Keshi.Entity;
using Keshi.Interfaces;
using Moq;
using NUnit.Framework;

namespace Kaeshi.Tests.CommandsTests
{
    class GoCommandTests
    {
        [Test]
        public void GoCommandReturnsPlay()
        {
            GameState expected = GameState.Play;
            var map = new Mock<IMap>();

            var command = new GoCommand(map.Object, Direction.North);
            var actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }
    }
}
