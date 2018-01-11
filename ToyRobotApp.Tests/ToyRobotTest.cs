using System;
using ToyRobotApp.Contracts;
using Xunit;

namespace ToyRobotApp.Tests
{
    public class ToyRobotTest
    {
        private const int BOUNDARYAREA = 5;
        private static IToyRobot CreateSut()
        {
            return new ToyRobot(BOUNDARYAREA);
        }

        #region "Validation Tests"

        [Fact]
        public void Test_ValidationRule_OnlyPlaceCommandIsFirstValidCommand()
        {
            var toyRobot = CreateSut();

            Assert.Throws<Exception>(() => toyRobot.Move());
            Assert.Throws<Exception>(() => toyRobot.Left());
            Assert.Throws<Exception>(() => toyRobot.Right());
            Assert.Throws<Exception>(() => toyRobot.Report());
            toyRobot.Place(new RobotPosition()
            {
                X = 0,
                Y = 0,
                F = Direction.NORTH
            });
        }

        [Fact]
        public void Test_ValidationRule_InvalidMovePreservesTheLastValidValue()
        {
            var toyRobot = CreateSut();

            toyRobot.Place(new RobotPosition()
            {
                X = 0,
                Y = 1,
                F = Direction.NORTH
            });
            toyRobot.Left();
            var position1 = toyRobot.Report();

            Assert.Throws<System.Exception>(() => toyRobot.Move());
            var currentPosition = toyRobot.Report();
            Assert.Equal(position1.X, currentPosition.X);
            Assert.Equal(position1.Y, currentPosition.Y);
            Assert.Equal(position1.F, currentPosition.F);

        }

        [Theory]
        [InlineData(-BOUNDARYAREA, -BOUNDARYAREA, Direction.NORTH)]
        [InlineData(BOUNDARYAREA + 1, BOUNDARYAREA + 2, Direction.NORTH)]
        [InlineData(-2, 3, Direction.NORTH)]
        [InlineData(2, -3, Direction.NORTH)]
        public void Test_ValidationRule_InvalidPlaceCommandThrowsException(int x, int y, Direction f)
        {
            IToyRobot toyRobot = CreateSut();

            Assert.Throws<Exception>(() => toyRobot.Place(new RobotPosition()
            {
                X = x,
                Y = y,
                F = f
            }));
        }

        #endregion

        #region "Command Tests"

        [Theory]
        [InlineData(0, BOUNDARYAREA, Direction.NORTH)]
        [InlineData(3, 2, Direction.EAST)]
        [InlineData(BOUNDARYAREA, 0, Direction.WEST)]
        public void Test_PlaceCommand_SetsCurrentPosition(int x, int y, Direction f)
        {
            IToyRobot toyRobot = CreateSut();

            toyRobot.Place(new RobotPosition()
            {
                X = x,
                Y = y,
                F = f
            });
            var currentPosition = toyRobot.Report();

            Assert.Equal(x, currentPosition.X);
            Assert.Equal(y, currentPosition.Y);
            Assert.Equal(f, currentPosition.F);
        }

        [Theory]
        [InlineData(1, 2, Direction.NORTH, 1, 3, Direction.NORTH)]
        [InlineData(1, 2, Direction.SOUTH, 1, 1, Direction.SOUTH)]
        [InlineData(1, 2, Direction.EAST, 2, 2, Direction.EAST)]
        [InlineData(1, 2, Direction.WEST, 0, 2, Direction.WEST)]
        public void Test_MoveCommand_OneUnitInCurrentDirection(int x1, int y1, Direction f1, int x2, int y2, Direction f2)
        {
            IToyRobot toyRobot = CreateSut();

            toyRobot.Place(new RobotPosition()
            {
                X = x1,
                Y = y1,
                F = f1
            });
            toyRobot.Move();
            var currentPosition = toyRobot.Report();

            Assert.Equal(x2, currentPosition.X);
            Assert.Equal(y2, currentPosition.Y);
            Assert.Equal(f2, currentPosition.F);
        }

        [Theory]
        [InlineData(0, BOUNDARYAREA, Direction.NORTH, Direction.WEST)]
        [InlineData(0, BOUNDARYAREA, Direction.SOUTH, Direction.EAST)]
        [InlineData(0, BOUNDARYAREA, Direction.EAST, Direction.NORTH)]
        [InlineData(0, BOUNDARYAREA, Direction.WEST, Direction.SOUTH)]
        public void Test_LeftCommand_RotatesPerpendicularInLeftDirection(int x, int y, Direction currentDirection, Direction expectedDirection)
        {
            IToyRobot toyRobot = CreateSut();

            toyRobot.Place(new RobotPosition()
            {
                X = x,
                Y = y,
                F = currentDirection
            });
            toyRobot.Left();
            var currentPosition = toyRobot.Report();

            Assert.Equal(x, currentPosition.X);
            Assert.Equal(y, currentPosition.Y);
            Assert.Equal(expectedDirection, currentPosition.F);
        }

        [Theory]
        [InlineData(0, BOUNDARYAREA, Direction.NORTH, Direction.EAST)]
        [InlineData(0, BOUNDARYAREA, Direction.SOUTH, Direction.WEST)]
        [InlineData(0, BOUNDARYAREA, Direction.EAST, Direction.SOUTH)]
        [InlineData(0, BOUNDARYAREA, Direction.WEST, Direction.NORTH)]
        public void Test_RightCommand_RotatesPerpendicularInRightDirection(int x, int y, Direction currentDirection, Direction expectedDirection)
        {
            IToyRobot toyRobot = CreateSut();

            toyRobot.Place(new RobotPosition()
            {
                X = x,
                Y = y,
                F = currentDirection
            });
            toyRobot.Right();
            var currentPosition = toyRobot.Report();

            Assert.Equal(x, currentPosition.X);
            Assert.Equal(y, currentPosition.Y);
            Assert.Equal(expectedDirection, currentPosition.F);
        }

        #endregion
    }
}
