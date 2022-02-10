using Kaeshi.Commands;
using Kaeshi.Entity;
using Kaeshi.Interfaces;
using Moq;
using NUnit.Framework;

namespace Kaeshi.Tests.CommandsTests
{
    class AttackCommandTests
    {
        [Test]
        public void AttackCommandReturnsPlayWhenHeroAlive()
        {
            GameState expected = GameState.Play;

            var hero = new Mock<IBattler>();
            hero.Setup(h => h.IsAlive()).Returns(true);
            var enemy = new Mock<IBattler>();
            enemy.Setup(e => e.IsAlive()).Returns(true);
            var location = new Mock<Location>("foo", "bar");

            ICommand command = new AttackCommand(hero.Object, enemy.Object,location.Object);

            var result = command.Execute();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AttackCommandReturnsLostWhenHeroDead()
        {
            GameState expected = GameState.Lost;

            var hero = new Mock<IBattler>();
            hero.Setup(h => h.IsAlive()).Returns(false);
            var enemy = new Mock<IBattler>();
            enemy.Setup(e => e.IsAlive()).Returns(true);
            var location = new Mock<Location>("foo","bar");

            ICommand command = new AttackCommand(hero.Object, enemy.Object, location.Object);

            var result = command.Execute();

            Assert.AreEqual(expected, result);
        }
    }
}
