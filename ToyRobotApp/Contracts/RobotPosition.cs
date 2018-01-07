namespace ToyRobotApp.Contracts
{
    /// <summary>
    /// Position of the toy robot
    /// </summary>
    public class RobotPosition
    {
        /// <summary>
        /// X axis value in a 2D plane
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y axis value in a 2D plane
        /// </summary>
        public int Y { get; set; }
       
        /// <summary>
        /// Direction value : NORTH, SOUTH, EAST, WEST
        /// </summary>
        public Direction F { get; set; }

    }


    /// <summary>
    /// Indicate the direction
    /// </summary>
    public enum Direction {
        NORTH,
        SOUTH, 
        EAST, 
        WEST
    }
}
