using System;
using ToyRobotApp.Contracts;

namespace ToyRobotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing toy robot application ...\n");
            Console.WriteLine("\tValid set of commands");
            Console.WriteLine("\t1. PLACE X,Y,F");
            Console.WriteLine("\t2. MOVE");
            Console.WriteLine("\t3. LEFT");
            Console.WriteLine("\t4. RIGHT");
            Console.WriteLine("\t5. REPORT");
            Console.WriteLine("\nHave fun moving the robot around in a 5X5 square table top.");

            var toyRobot = new ToyRobot(5);

            while (true)
            {
                var readCommand = Console.ReadLine();

                try
                {
                    var command = readCommand.Split(' ');

                    switch (command[0].ToUpper())
                    {
                        case "PLACE":
                            var newPosition = GetNewPosition(command);
                            toyRobot.Place(newPosition);
                            break;

                        case "MOVE":
                            toyRobot.Move();
                            break;

                        case "LEFT":
                            toyRobot.Left();
                            break;

                        case "RIGHT":
                            toyRobot.Right();
                            break;

                        case "REPORT":
                            var robotPosition = toyRobot.Report();
                            Console.WriteLine("Current Position : {0}, {1}, {2}", robotPosition.X, robotPosition.Y, robotPosition.F.ToString());
                            break;

                        default:
                            Console.WriteLine("Command does not match valid command list. Please try again.");
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }

        /// <summary>
        /// Get the proposed new position for the place command. 
        /// Does validation check as well 
        /// </summary>
        /// <param name="command">Command to place a toy robot</param>
        /// <returns>Proposed position</returns>
        private static RobotPosition GetNewPosition(string[] command)
        {
            if (command.Length < 2)
            {
                throw new Exception("Missing parameters.");
            }

            var parameters = command[1].Split(',');

            if (parameters.Length < 3)
            {
                throw new Exception("Missing parameters.");
            }

            var x = int.Parse(parameters[0]);
            var y = int.Parse(parameters[1]);
            var f = parameters[2].ToUpper();
            var direction = (Direction)Enum.Parse(typeof(Direction), f);

            var newPosition = new RobotPosition()
            {
                X = x,
                Y = y,
                F = direction
            };
            return newPosition;
        }
    }
}
