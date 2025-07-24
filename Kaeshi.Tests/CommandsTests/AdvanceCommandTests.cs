using Kaeshi.Commands;
using Kaeshi.Entity;
using Kaeshi.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.IO;

namespace Kaeshi.Tests.CommandsTests
{
    public class AdvanceCommandTests
    {
        [Test]
        public void AdvanceCommandCantAdvanceOnRegularLocation()
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

                Assert.AreEqual("There's no way to next floor here", sw.ToString().Trim());
                Assert.AreEqual(GameState.Play, result);
            }
        }
    }
}
