using Keshi.Commands;
using Keshi.Entity;
using NUnit.Framework;

namespace Kaeshi.Tests.CommandsTests
{
    class GoCommandTests
    {
        [Test]
        public void GoCommandReturnsPlay()
        {
            GameState expected = GameState.Play;
            Map map = new Map();

            var command = new GoCommand(map, Direction.North);
            var actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }
    }
}
