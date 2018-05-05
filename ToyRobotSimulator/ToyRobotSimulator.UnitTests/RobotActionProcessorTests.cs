namespace ToyRobotSimulator.UnitTests
{
    using Console;
    using Console.Commands;
    using Console.Interfaces;
    using Console.Models;
    using NUnit.Framework;
    using ToyRobotSimulator;
        
    [TestFixture]
    public class RobotActionProcessorTests
    {
        private IRobotActionProcessor _robotActionProcessor;

        [SetUp]
        public void SetUp()
        {
            IRobot robot = new Robot();
            var table = new int[5, 5];
            _robotActionProcessor = new RobotActionProcessor(robot, table);
        }

        [TestCase(0, 0, Facing.East)]
        [TestCase(1, 0, Facing.North)]
        [TestCase(2, 2, Facing.West)]
        [TestCase(4, 4, Facing.South)]
        public void PlaceTest_When_ObjectIsPlacedAtPosition_ExpectObjectAtThatPosition(int xPosition, int yPosition, Facing facing)
        {
            var positionToPlace = new ObjectPosition
                                  {
                                      Facing = facing,
                                      XPosition = xPosition,
                                      YPosition = yPosition
                                  };

            var actualPosition = _robotActionProcessor.Process(new PlaceCommand(positionToPlace));

            Assert.AreEqual(actualPosition.Facing, facing);
            Assert.AreEqual(actualPosition.XPosition, xPosition);
            Assert.AreEqual(actualPosition.YPosition, yPosition);
        }

        [Test]
        public void PlaceTest_When_ObjectIsPlacedAtInvalidPosition_Expect_Null()
        {
            var positionToPlace = new ObjectPosition
                                  {
                                      Facing = Facing.East,
                                      XPosition = 2,
                                      YPosition = 8
                                  };

            var actualPosition = _robotActionProcessor.Process(new PlaceCommand(positionToPlace));

            Assert.IsNull(actualPosition);
        }

        [Test]
        public void MoveTest_WhenObjectIsNotPlaced_Expect_ObjectPosition_AsNull()
        {
            var objectPosition = _robotActionProcessor.Process(new MoveCommand());

            Assert.AreEqual(objectPosition, null);
        }

        [TestCase(0, 0, Facing.North, 0, 1, Facing.North)]
        [TestCase(1, 1, Facing.South, 1, 0, Facing.South)]
        [TestCase(3, 2, Facing.North, 3, 3, Facing.North)]
        [TestCase(1, 4, Facing.East, 2, 4, Facing.East)]
        [TestCase(4, 4, Facing.West, 3, 4, Facing.West)]
        public void MoveTest_WhenObjectIsPlacedAt_And_Moved_Expect_ObjectPositionAt(int startXPos, int startYPos, Facing startFacing, int endXPos, int endYPos, Facing endFacing)
        {
            _robotActionProcessor.Process(
                new PlaceCommand(
                    new ObjectPosition
                    {
                        XPosition = startXPos,
                        YPosition = startYPos,
                        Facing = startFacing
                    }));
            var objectPosition = _robotActionProcessor.Process(new MoveCommand());

            Assert.AreEqual(endFacing, objectPosition.Facing);
            Assert.AreEqual(endXPos, objectPosition.XPosition);
            Assert.AreEqual(endYPos, objectPosition.YPosition);
        }

        [Test]
        public void LeftTest_WhenObjectIsNotPlaced_Expect_ObjectPosition_AsNull()
        {
            var objectPosition = _robotActionProcessor.Process(new LeftCommand());

            Assert.AreEqual(objectPosition, null);
        }

        [TestCase(Facing.North, Facing.West)]
        [TestCase(Facing.West, Facing.South)]
        [TestCase(Facing.East, Facing.North)]
        [TestCase(Facing.South, Facing.East)]
        public void LeftTest_WhenObjectFacingAt_TurnsToLeftFacing(Facing startFacing, Facing endFacing)
        {
            _robotActionProcessor.Process(
                new PlaceCommand(
                    new ObjectPosition
                    {
                        XPosition = 0,
                        YPosition = 0,
                        Facing = startFacing
                    }));
            var objectPosition = _robotActionProcessor.Process(new LeftCommand());

            Assert.AreEqual(endFacing, objectPosition.Facing);
        }

        [Test]
        public void RightTest_WhenObjectIsNotPlaced_Expect_ObjectPosition_AsNull()
        {
            var objectPosition = _robotActionProcessor.Process(new RightCommand());

            Assert.AreEqual(objectPosition, null);
        }

        [TestCase(Facing.North, Facing.East)]
        [TestCase(Facing.West, Facing.North)]
        [TestCase(Facing.East, Facing.South)]
        [TestCase(Facing.South, Facing.West)]
        public void RightTest_WhenObjectFacingAt_TurnsToRightFacing(Facing startFacing, Facing endFacing)
        {
            _robotActionProcessor.Process(
                new PlaceCommand(
                    new ObjectPosition
                    {
                        XPosition = 0,
                        YPosition = 0,
                        Facing = startFacing
                    }));
            var objectPosition = _robotActionProcessor.Process(new RightCommand());

            Assert.AreEqual(endFacing, objectPosition.Facing);
        }

        [Test]
        public void ReportTest_When_ObjectIsNotPlaced_Expect_Null()
        {
            var objectPosition = _robotActionProcessor.Process(new ReportCommand());

            Assert.AreEqual(objectPosition, null);
        }

        [Test]
        public void HelpTest_AlwaysReturn_Null()
        {
            var objectPosition = _robotActionProcessor.Process(new ReportCommand());

            Assert.AreEqual(objectPosition, null);
        }

        [Test]
        public void InvalidTest_AlwaysReturn_Null()
        {
            var objectPosition = _robotActionProcessor.Process(new ReportCommand());

            Assert.AreEqual(objectPosition, null);
        }

        [TestCase(Facing.East, 1, 2, Facing.North, 3, 3)]
        [TestCase(Facing.West, 0, 0, Facing.South, 0, 0)]
        [TestCase(Facing.North, 0, 0, Facing.West, 0, 2)]
        [TestCase(Facing.South, 0, 0, Facing.East, 1, 0)]
        public void Test_CommnadSequence_PlaceAt_Move_Move_Left_Move_ExpectObjectPositionAt(Facing facing, int xPosition, int yPosition, Facing endFacing, int endXPosition, int endYPosition)
        {
            _robotActionProcessor.Process(
                new PlaceCommand(
                    new ObjectPosition
                    {
                        Facing = facing,
                        XPosition = xPosition,
                        YPosition = yPosition
                    }));
            _robotActionProcessor.Process(new MoveCommand());
            _robotActionProcessor.Process(new MoveCommand());
            _robotActionProcessor.Process(new LeftCommand());
            var objectPosition = _robotActionProcessor.Process(new MoveCommand());

            Assert.AreEqual(endFacing, objectPosition.Facing);
            Assert.AreEqual(endXPosition, objectPosition.XPosition);
            Assert.AreEqual(endYPosition, objectPosition.YPosition);
        }

        [TestCase(Facing.East, 0, 0, Facing.North, 0, 0)]
        [TestCase(Facing.West, 0, 0, Facing.South, 0, 0)]
        [TestCase(Facing.North, 0, 0, Facing.West, 0, 0)]
        [TestCase(Facing.South, 0, 0, Facing.East, 0, 0)]
        public void Test_CommandSequence_PlaceAt_And_Left_ExpectObjectPositionAt(Facing facing, int xPosition, int yPosition, Facing endFacing, int endXPosition, int endYPosition)
        {
            _robotActionProcessor.Process(
                new PlaceCommand(
                    new ObjectPosition
                    {
                        Facing = facing,
                        XPosition = xPosition,
                        YPosition = yPosition
                    }));
            var objectPosition = _robotActionProcessor.Process(new LeftCommand());

            Assert.AreEqual(endFacing, objectPosition.Facing);
            Assert.AreEqual(endXPosition, objectPosition.XPosition);
            Assert.AreEqual(endYPosition, objectPosition.YPosition);
        }

        [TestCase(Facing.North, 0, 0, Facing.North, 0, 1)]
        [TestCase(Facing.West, 0, 0, Facing.West, 0, 0)]
        [TestCase(Facing.South, 0, 0, Facing.South, 0, 0)]
        [TestCase(Facing.East, 0, 0, Facing.East, 1, 0)]
        [TestCase(Facing.South, 4, 0, Facing.South, 4, 0)]
        [TestCase(Facing.East, 4, 0, Facing.East, 4, 0)]
        [TestCase(Facing.North, 4, 4, Facing.North, 4, 4)]
        [TestCase(Facing.East, 4, 4, Facing.East, 4, 4)]
        [TestCase(Facing.West, 0, 4, Facing.West, 0, 4)]
        [TestCase(Facing.North, 0, 4, Facing.North, 0, 4)]
        public void Test_CommandSequence_PlaceAt_And_Move_ExpectObjectPositionAt(Facing facing, int xPosition, int yPosition, Facing endFacing, int endXPosition, int endYPosition)
        {
            _robotActionProcessor.Process(
                new PlaceCommand(
                    new ObjectPosition
                    {
                        Facing = facing,
                        XPosition = xPosition,
                        YPosition = yPosition
                    }));
            var objectPosition = _robotActionProcessor.Process(new MoveCommand());

            Assert.AreEqual(endFacing, objectPosition.Facing);
            Assert.AreEqual(endXPosition, objectPosition.XPosition);
            Assert.AreEqual(endYPosition, objectPosition.YPosition);
        }
    }
}