using Kaeshi.Commands;
using Kaeshi.Entity;
using Kaeshi.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.IO;

namespace Kaeshi.Tests.CommandsTests
{
    [TestOf(typeof(AdvanceCommand))]
    public class AdvanceCommandTests
    {
        [Test]
        public void AdvanceCommandCanNotAdvanceOnRegularLocation()
        {
            var map = new Mock<IMap>();
            var location = new Location("foo", "bar");
            map.Setup(m => m.GetCurrentLocation()).Returns(location);
            var backpack = new Mock<IBackpack>();
            var command = new AdvanceCommand(map.Object, backpack.Object);

            using(StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var result = command.Execute();

                Console.SetOut(Console.Out);

                map.Verify(m => m.Advance(), Times.Never);
                Assert.AreEqual("There's no way to next floor here", sw.ToString().Trim());
                Assert.AreEqual(GameState.Play, result);
            }
        }

        [Test]
        public void AdvanceCommandCanAdvanceOnFinalLocationWithKey()
        {
            var map = new Mock<IMap>();
            var location = new Location("foo", "bar");
            location.SetFinalLocation("key");
            map.Setup(m => m.GetCurrentLocation()).Returns(location);
            var backpack = new Mock<IBackpack>();
            backpack.Setup(b => b.ItemInBackpack(It.IsAny<string>())).Returns(true);
            var command = new AdvanceCommand(map.Object, backpack.Object);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var result = command.Execute();
                Console.SetOut(Console.Out);
                map.Verify(m => m.Advance(), Times.Once);
                Assert.AreEqual("You reached next floor!", sw.ToString().Trim());
                Assert.AreEqual(GameState.Play, result);
            }
        }

        [Test]
        public void AdvanceCommandCanNotAdvanceOnFinalLocationWithoutKey()
        {
            var keyName = "key";
            var map = new Mock<IMap>();
            var location = new Location("foo", "bar");
            location.SetFinalLocation(keyName);
            map.Setup(m => m.GetCurrentLocation()).Returns(location);
            var backpack = new Mock<IBackpack>();
            backpack.Setup(b => b.ItemInBackpack(It.IsAny<string>())).Returns(false);
            var command = new AdvanceCommand(map.Object, backpack.Object);
            using(StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var result = command.Execute();
                Console.SetOut(Console.Out);
                map.Verify(m => m.Advance(), Times.Never);
                Assert.AreEqual($"You don't have a {keyName} to advance!", sw.ToString().Trim());
                Assert.AreEqual(GameState.Play, result);
            }
        }
    }
}
