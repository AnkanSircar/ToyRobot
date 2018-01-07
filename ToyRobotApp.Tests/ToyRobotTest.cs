using System;
using ToyRobotApp.Contracts;
using Xunit;

namespace ToyRobotApp.Tests
{
    public class ToyRobotTest
    {
        private const int BOUNDARYAREA = 5;
        private IToyRobot CreateSut()
        {
            return new ToyRobot(BOUNDARYAREA);
        }

        #region "Validation Tests"

        [Fact]
        public void Test_ValidationRule_OnlyPlaceCommandIsFirstValidCommand()
        {
            IToyRobot toyRobot = CreateSut();

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
            IToyRobot toyRobot = CreateSut();

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

        [Fact]
        public void Test_MoveCommand_OneUnitInCurrentDirection()
        {
            IToyRobot toyRobot = CreateSut();

            toyRobot.Place(new RobotPosition()
            {
                X = 2,
                Y = 3,
                F = Direction.NORTH
            });
            toyRobot.Move();
            var currentPosition = toyRobot.Report();

            Assert.Equal(2, currentPosition.X);
            Assert.Equal(4, currentPosition.Y);
            Assert.Equal(Direction.NORTH, currentPosition.F);
        }

        [Fact]
        public void Test_LeftCommand_RotatesPerpendicularInLeftDirection()
        {
            IToyRobot toyRobot = CreateSut();

            toyRobot.Place(new RobotPosition()
            {
                X = 2,
                Y = 3,
                F = Direction.NORTH
            });
            toyRobot.Left();
            var currentPosition = toyRobot.Report();

            Assert.Equal(2, currentPosition.X);
            Assert.Equal(3, currentPosition.Y);
            Assert.Equal(Direction.WEST, currentPosition.F);
        }

        [Fact]
        public void Test_RightCommand_RotatesPerpendicularInRightDirection()
        {
            IToyRobot toyRobot = CreateSut();

            toyRobot.Place(new RobotPosition()
            {
                X = 2,
                Y = 3,
                F = Direction.NORTH
            });
            toyRobot.Right();
            var currentPosition = toyRobot.Report();

            Assert.Equal(2, currentPosition.X);
            Assert.Equal(3, currentPosition.Y);
            Assert.Equal(Direction.EAST, currentPosition.F);
        }

        #endregion
    }
}
