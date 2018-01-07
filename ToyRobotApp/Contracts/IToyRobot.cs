namespace ToyRobotApp.Contracts
{
    public interface IToyRobot
    {
        /// <summary>
        /// This command places the robot in a new position
        /// </summary>
        /// <param name="newPosition">Proposed position for the robot</param>
        void Place(RobotPosition newPosition);

        /// <summary>
        /// This command reports back the current position
        /// </summary>
        /// <returns>current position</returns>
        RobotPosition Report();

        /// <summary>
        /// This command moves the robot one unit forward in the direction it is currently facing.
        /// </summary>
        void Move();

        /// <summary>
        /// This command rotates the robot 90 degrees left side of the current direction without changing the position of the robot.
        /// </summary>
        void Left();

        /// <summary>
        /// This command rotates the robot 90 degrees right side of the current direction without changing the position of the robot.
        /// </summary>
        void Right();
    }    
}
