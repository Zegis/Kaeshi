﻿using Keshi.Commands;
using Keshi.Entity;
using Keshi.Interfaces;
using Moq;
using NUnit.Framework;

namespace Kaeshi.Tests.CommandsTests
{
    class LookCommandTests
    {
        [Test]
        public void LookCommandReturnsPlay()
        {
            var expected = GameState.Play;

            Mock<IVisible> target = new Mock<IVisible>();
            var command = new LookCommand(target.Object);

            var actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }
    }
}
