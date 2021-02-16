using Keshi.Commands;
using Keshi.Entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kaeshi.Tests.CommandsTests
{
    class SimpleCommandsTests
    {
        [Test]
        public void NotFoundCommandsReturnsPlayState()
        {
            GameState expected = GameState.Play;

            var command = new NotFoundCommand();
            var actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExitCommandsReturnsExitState()
        {
            GameState expected = GameState.Exit;

            var command = new ExitCommand();
            var actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }
    }
}
