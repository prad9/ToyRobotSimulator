namespace ToyRobotSimulator.UnitTests
{
    using System;
    using Console;
    using Console.Commands;
    using NUnit.Framework;

    [TestFixture]
    public class CommandParserTests
    {
        private CommandParser _commandParser;

        [TestCase("move", typeof(MoveCommand))]
        [TestCase("Move", typeof(MoveCommand))]
        [TestCase("MOVE", typeof(MoveCommand))]
        [TestCase("Left", typeof(LeftCommand))]
        [TestCase("right", typeof(RightCommand))]
        [TestCase("report", typeof(ReportCommand))]
        [TestCase("Place 0,0,North", typeof(PlaceCommand))]
        [TestCase("place 0,0,North", typeof(PlaceCommand))]
        [TestCase("help", typeof(HelpCommand))]
        [TestCase("help 0,0,North", typeof(InvalidCommand))]
        [TestCase("place 5,5,north", typeof(InvalidCommand))]
        [TestCase("place a,a,test", typeof(InvalidCommand))]
        [TestCase("place a,a,test,a", typeof(InvalidCommand))]
        [TestCase("place a,", typeof(InvalidCommand))]
        [TestCase(" ", typeof(InvalidCommand))]
        [TestCase("", typeof(InvalidCommand))]
        public void ParseTest_When_StringCommandPassedAsInput_ExpectCommand(string input, Type type)
        {
            var actualCommand = _commandParser.Parse(input);

            Assert.IsInstanceOf(type, actualCommand);
        }

        [SetUp]
        public void Setup()
        {
            _commandParser = new CommandParser();
        }
    }
}