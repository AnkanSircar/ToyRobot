using ToyRobotApp.Contracts;

namespace ToyRobotApp
{
    public class ToyRobot : IToyRobot
    {
        private RobotPosition robotPosition;
        private readonly int SQUARETABLETOPUNIT;

        private const string INVALIDPOSITIONERROR = "Invalid Position.";
        private const string INVALIDCOMMANDERROR = "Invalid command.";
        private const string INVALIDMOVEERROR = "Invalid Move.";

        public ToyRobot(int squareTableTopUnit)
        {
            SQUARETABLETOPUNIT = squareTableTopUnit;
        }
       
        public void Place(RobotPosition newPosition)
        {
            if (IsValidMove(newPosition))
            {
                robotPosition = newPosition;
            }
            else
            {
                throw new System.Exception(INVALIDPOSITIONERROR);
            }
        }

        public RobotPosition Report()
        {
            if (!IsValidCommand())
            {
                throw new System.Exception(INVALIDCOMMANDERROR);
            }

            return robotPosition;
        }

        public void Move()
        {
            if (!IsValidCommand())
            {
                throw new System.Exception(INVALIDCOMMANDERROR);
            }

            var newPosition = ApplyMove();

            if (IsValidMove(newPosition))
            {
                robotPosition = newPosition;
            }
            else
            {
                throw new System.Exception(INVALIDMOVEERROR);
            }
        }        

        public void Left()
        {
            if (!IsValidCommand())
            {
                throw new System.Exception(INVALIDCOMMANDERROR);
            }

            ApplyLeft();
        }
        
        public void Right()
        {
            if (!IsValidCommand())
            {
                throw new System.Exception(INVALIDCOMMANDERROR);
            }

            ApplyRight();
        }
        

        #region Helper methods

        /// <summary>
        /// Calculates a new position applying one unit move in current direction
        /// </summary>
        /// <returns>Calculated new position</returns>
        private RobotPosition ApplyMove()
        {
            // initialize
            var newPosition = new RobotPosition()
            {
                X = robotPosition.X,
                Y = robotPosition.Y,                
                F = robotPosition.F
            };

            if (robotPosition.F == Direction.NORTH)
            {
                newPosition.Y++;
            }
            else if (robotPosition.F == Direction.SOUTH)
            {
                newPosition.Y--;
            }
            else if (robotPosition.F == Direction.EAST)
            {
                newPosition.X++;
            }
            else if (robotPosition.F == Direction.WEST)
            {
                newPosition.X--;
            }

            return newPosition;
        }

        /// <summary>
        /// Applies 90 degree movement left side of the current direction
        /// </summary>
        private void ApplyLeft()
        {
            switch (robotPosition.F)
            {
                case Direction.NORTH:
                    robotPosition.F = Direction.WEST;
                    break;
                case Direction.SOUTH:
                    robotPosition.F = Direction.EAST;
                    break;
                case Direction.EAST:
                    robotPosition.F = Direction.NORTH;
                    break;
                case Direction.WEST:
                    robotPosition.F = Direction.SOUTH;
                    break;
            }
        }

        /// <summary>
        /// Applies 90 degree movement right side of the current direction
        /// </summary>
        private void ApplyRight()
        {
            switch (robotPosition.F)
            {
                case Direction.NORTH:
                    robotPosition.F = Direction.EAST;
                    break;
                case Direction.SOUTH:
                    robotPosition.F = Direction.WEST;
                    break;
                case Direction.EAST:
                    robotPosition.F = Direction.SOUTH;
                    break;
                case Direction.WEST:
                    robotPosition.F = Direction.NORTH;
                    break;
            }
        }

        /// <summary>
        /// Validates if the position is a valid robot position
        /// </summary>
        /// <param name="position">New proposed robot position</param>
        /// <returns>Indicates a valid move (true/false)</returns>
        private bool IsValidMove(RobotPosition position)
        {
            if(position.X > SQUARETABLETOPUNIT || position.X < 0)
            {
                return false;
            }

            if (position.Y > SQUARETABLETOPUNIT || position.Y < 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// PLACE command should be the first command in a command sequence, otherwise robot won't be initialized 
        /// </summary>
        /// <returns>Indicates a valid command (true/false)</returns>
        private bool IsValidCommand()
        {
            return robotPosition != null;
        }

        #endregion

    }
}
