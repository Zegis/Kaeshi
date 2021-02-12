using Keshi.Commands;
using Keshi.Modules;
using NUnit.Framework;

namespace Kaeshi.Tests
{
    public class CommandParserTests
    {
        public CommandParser parser;

        [SetUp]
        public void Setup()
        {
            var entityManager = new EntityManager();
            parser = new CommandParser(entityManager);
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
    }
}