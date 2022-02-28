using Kaeshi.Commands;
using Kaeshi.Entity;
using Kaeshi.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

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

        [Test]
        public void AttackCommandReturnsWhenNoOneToHit()
        {
            var hero = new Mock<IBattler>();
            var location = new Mock<Location>("foo", "bar");

            ICommand command = new AttackCommand(hero.Object, null, location.Object);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                command.Execute();

                Assert.AreEqual("Nothing to attack", sw.ToString());

                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            }
        }

        [Test]
        public void AttackCommandReturnsPlayAndDeadEnemyDropsLoot()
        {
            var loot = new List<Item>()
            {
                new Item("foo","bar")
            };
            GameState expectedState = GameState.Play;

            var hero = new Mock<IBattler>();
            hero.Setup(h => h.IsAlive()).Returns(true);
            var enemy = new Mock<IBattler>();
            enemy.Setup(e => e.IsAlive()).Returns(false);
            enemy.Setup(e => e.DropItems()).Returns(loot);
            var location = new Mock<Location>("foo", "bar");
            location.Setup(l => l.AddItem(It.IsAny<string>(), It.IsAny<Item>())).Verifiable();

            ICommand command = new AttackCommand(hero.Object, enemy.Object, location.Object);

            var result = command.Execute();

            Assert.AreEqual(expectedState, result);
            location.Verify(l => l.AddItem(It.IsAny<string>(), It.IsAny<Item>()), Times.Once);
        }

        [Test]
        public void AttackCommandOnlyHitBattlerGotInjuries()
        {
            var battler_hit = new Mock<IBattler>();
            var battler_no_hit = new Mock<IBattler>();
            var location = new Mock<Location>("foo", "bar");

            battler_hit.Setup(e => e.IsAlive()).Returns(true);
            battler_hit.Setup(e => e.IsHit(It.IsAny<int>())).Returns(true);
            battler_hit.Setup(e => e.Injure(It.IsAny<int>())).Verifiable();

            battler_no_hit.Setup(e => e.IsAlive()).Returns(true);
            battler_no_hit.Setup(e => e.IsHit(It.IsAny<int>())).Returns(false);
            battler_no_hit.Setup(e => e.Injure(It.IsAny<int>())).Verifiable();

            ICommand command = new AttackCommand(battler_hit.Object, battler_no_hit.Object, location.Object);

            command.Execute();

            battler_hit.Verify(e => e.Injure(It.IsAny<int>()), Times.Once);
            battler_no_hit.Verify(e => e.Injure(It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void AttackCommandDeadDontRetaliate()
        {
            var battler_alive = new Mock<IBattler>();
            var battler_dead = new Mock<IBattler>();
            var location = new Mock<Location>("foo", "bar");

            battler_alive.Setup(e => e.IsAlive()).Returns(true);
            battler_alive.Setup(e => e.IsHit(It.IsAny<int>())).Returns(true);
            battler_alive.Setup(e => e.Injure(It.IsAny<int>())).Verifiable();

            battler_dead.SetupSequence(e => e.IsAlive()).Returns(true).Returns(false);
            battler_dead.Setup(e => e.IsHit(It.IsAny<int>())).Returns(true);
            battler_dead.Setup(e => e.Injure(It.IsAny<int>())).Verifiable();

            ICommand command = new AttackCommand(battler_alive.Object, battler_dead.Object, location.Object);

            command.Execute();

            battler_alive.Verify(e => e.Injure(It.IsAny<int>()), Times.Never);
            battler_dead.Verify(e => e.Injure(It.IsAny<int>()), Times.Once);
        }
    }
}
