using ToyRobotApp.Contracts;

namespace ToyRobotApp
{
    public class ToyRobot : IToyRobot
    {
        private RobotPosition robotPosition;
        private readonly int SQUARETABLETOPUNIT;

        private const string ERROR_INVALIDPOSITION = "Invalid Position.";
        private const string ERROR_INVALIDCOMMAND = "Invalid command.";
        private const string ERROR_INVALIDMOVE = "Invalid Move.";

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
                throw new System.Exception(ERROR_INVALIDPOSITION);
            }
        }

        public RobotPosition Report()
        {
            if (!IsValidCommand())
            {
                throw new System.Exception(ERROR_INVALIDCOMMAND);
            }

            return robotPosition;
        }

        public void Move()
        {
            if (!IsValidCommand())
            {
                throw new System.Exception(ERROR_INVALIDCOMMAND);
            }

            var newPosition = ApplyMove();

            if (IsValidMove(newPosition))
            {
                robotPosition = newPosition;
            }
            else
            {
                throw new System.Exception(ERROR_INVALIDMOVE);
            }
        }        

        public void Left()
        {
            if (!IsValidCommand())
            {
                throw new System.Exception(ERROR_INVALIDCOMMAND);
            }

            ApplyLeft();
        }
        
        public void Right()
        {
            if (!IsValidCommand())
            {
                throw new System.Exception(ERROR_INVALIDCOMMAND);
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
            if (robotPosition.F == Direction.NORTH)
            {
                robotPosition.F = Direction.WEST;
            }
            else if (robotPosition.F == Direction.SOUTH)
            {
                robotPosition.F = Direction.EAST;
            }
            else if (robotPosition.F == Direction.EAST)
            {
                robotPosition.F = Direction.NORTH;
            }
            else if (robotPosition.F == Direction.WEST)
            {
                robotPosition.F = Direction.SOUTH;
            }
        }

        /// <summary>
        /// Applies 90 degree movement right side of the current direction
        /// </summary>
        private void ApplyRight()
        {
            if (robotPosition.F == Direction.NORTH)
            {
                robotPosition.F = Direction.EAST;
            }
            else if (robotPosition.F == Direction.SOUTH)
            {
                robotPosition.F = Direction.WEST;
            }
            else if (robotPosition.F == Direction.EAST)
            {
                robotPosition.F = Direction.SOUTH;
            }
            else if (robotPosition.F == Direction.WEST)
            {
                robotPosition.F = Direction.NORTH;
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
            return robotPosition == null ? false : true;
        }

        #endregion

    }
}
