using Kaeshi.Commands;
using Kaeshi.Interfaces;
using Kaeshi.Modules;
using Kaeshi.Entity;
using Moq;
using NUnit.Framework;

namespace Kaeshi.Tests
{
    public class CommandParserTests
    {
        public CommandParser parser;

        [SetUp]
        public void Setup()
        {
            var map = new Mock<Map>();
            var currentLocation = new Mock<Location>("foo", "bar");
            map.Setup(x => x.GetCurrentLocation()).Returns(currentLocation.Object);
            var entityManager = new Mock<IEntityManager>();
            entityManager.Setup(x => x.GetHero()).Returns(new Character(1,1,10));
            entityManager.Setup(x => x.GetMap()).Returns(map.Object);
            parser = new CommandParser(entityManager.Object);
        }

        [Test]
        public void EmptyStringIsNotCommand()
        {
            var expected = new NotFoundCommand().GetType();
            var command = parser.Parse(string.Empty);

            Assert.AreEqual(expected, command.GetType());
        }

        [Test]
        public void Length0StringIsNotCommand()
        {
            var expected = new NotFoundCommand().GetType();
            var command = parser.Parse("");

            Assert.AreEqual(expected, command.GetType());
        }

        [Test]
        public void ThreePiecesStringIsNotCommand()
        {
            var expected = new NotFoundCommand().GetType();
            var command = parser.Parse("Look yourself now");

            Assert.AreEqual(expected, command.GetType());
        }

        [Test]
        public void GiberrishStringIsNotCommand()
        {
            var expected = new NotFoundCommand().GetType();
            var command = parser.Parse("Hello world!");

            Assert.AreEqual(expected, command.GetType());
        }

        [Test]
        public void ParserIsCaseInsensitive()
        {
            var expected = new ExitCommand().GetType();
            var command = parser.Parse("ExIt");

            Assert.AreEqual(expected, command.GetType());
        }

        [Test]
        public void ExitIsValidCommand()
        {
            var expected = new ExitCommand().GetType();
            var command = parser.Parse("exit");

            Assert.AreEqual(expected, command.GetType());
        }

        [Test]
        public void DirectionsAreValidCommands()
        {
            var expected = typeof(GoCommand);
            
            var command = parser.Parse("north");
            Assert.AreEqual(expected, command.GetType());

            command = parser.Parse("south");
            Assert.AreEqual(expected, command.GetType());

            command = parser.Parse("west");
            Assert.AreEqual(expected, command.GetType());

            command = parser.Parse("east");
            Assert.AreEqual(expected, command.GetType());
        }

        [Test]
        public void TakeIsValidCommand()
        {
            var expected = typeof(TakeCommand);

            var command = parser.Parse("take");

            Assert.AreEqual(expected, command.GetType());
        }

        [Test]
        public void AttackIsValidCommands()
        {
            var expected = typeof(AttackCommand);

            var command = parser.Parse("attack");
            Assert.AreEqual(expected, command.GetType());
        }

        [Test]
        public void LookIsValidCommands()
        {
            var expected = typeof(LookCommand);

            var command = parser.Parse("look");
            Assert.AreEqual(expected, command.GetType());
        }

        [Test]
        public void OpenIsValidCommand()
        {
            var expected = typeof(OpenInventoryCommand);
            var command = parser.Parse("open");
            Assert.AreEqual(expected, command.GetType());
        }

        [Test]
        public void UseIsValidCommand()
        {

            var expected = typeof(UseCommand);
            var command = parser.Parse("use");
            Assert.AreEqual(expected, command.GetType());
        }

        [Test]
        public void EquipIsValidCommand()
        {

            var expected = typeof(EquipCommand);
            var command = parser.Parse("equip");
            Assert.AreEqual(expected, command.GetType());
        }

        [Test]
        public void UnEquipIsValidCommand()
        {
            var expected = typeof(UnequipCommand);
            var command = parser.Parse("unequip Armor");
            Assert.AreEqual(expected, command.GetType());
        }
    }
}